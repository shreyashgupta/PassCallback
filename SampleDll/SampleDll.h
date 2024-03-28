#include <string>
#include <iostream>
#include <thread>

typedef int(__stdcall* CallbackFunction)(const char* str);

class SampleClass {
	CallbackFunction _callback;
public:
	SampleClass(CallbackFunction callback) : _callback(callback) {};
	void trigger_callback();
};

const char* secret = "shreyash";
extern "C" __declspec(dllexport) const char* GetSecret() {
	return secret;
}

void start_thread(CallbackFunction callback) {
	auto instance = new SampleClass(callback);

	while (1) {
		instance->trigger_callback();
		Sleep(1000);
	}
}

extern "C" __declspec(dllexport) void PassFunc(CallbackFunction callback) {
	std::thread t(start_thread, callback);
	t.join();
}

