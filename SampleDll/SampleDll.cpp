// SampleDll.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "SampleDll.h"

std::string generateRandomString(int length) {
    static const char alphanum[] =
        "0123456789"
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        "abcdefghijklmnopqrstuvwxyz";

    std::string random_string;
    random_string.reserve(length);

    for (int i = 0; i < length; ++i) {
        random_string += alphanum[rand() % (sizeof(alphanum) - 1)];
    }

    return random_string;
}

void SampleClass::trigger_callback()
{
    auto ret = _callback(generateRandomString(10).c_str());
    std::cout << "Got val " << ret << std::endl;
}