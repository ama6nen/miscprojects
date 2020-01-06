#include "pch.h"
#include "CppUnitTest.h"
#include "../UnitTestingCPP/TestClass.hpp"
#include <random>
#include <chrono>
using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace meme {
	std::mt19937 rng;
	int random(int min, int max)
	{
		static bool seeded = false;
		if (!seeded) {
			rng.seed((unsigned int)std::chrono::high_resolution_clock::now().time_since_epoch().count());
			seeded = true;
		}
		std::uniform_int_distribution<int> distribution(min, max);
		return distribution(rng);
	}
	std::string randomletters(size_t length)
	{
		static auto randchar = []() -> char {
			const char charset[] =
				"qwertyuiopasdfghjklzxcvbnm"
				"QWERTYUIOPASDFGHJKLZXCVBNM";
			const size_t max_index = (sizeof(charset) - 1);
			return charset[random(INT16_MAX, INT32_MAX) % max_index];
		};

		std::string str(length, 0);
		std::generate_n(str.begin(), length, randchar);
		return str;
	}
	std::string randomothers(size_t length)
	{
		static auto randchar = []() -> char {
			const char charset[] =
				"0123456789"
				"+!#¤%&/()=?``^^**_:;,.-";
			const size_t max_index = (sizeof(charset) - 1);
			return charset[random(INT16_MAX, INT32_MAX) % max_index];
		};

		std::string str(length, 0);
		std::generate_n(str.begin(), length, randchar);
		return str;
	}
}
namespace UnitTestCPP
{
	TEST_CLASS(UnitTestCPP)
	{
	public:
		
		TEST_METHOD(Test_CPP)
		{
			auto instance = TestClass2();
			Assert::AreEqual(0, instance.GetCorrectedData(), L"incorrect default value");
			Assert::AreEqual(std::string(""), instance.GetLettersOnly(), L"incorrect default value");

			for (int i = 0; i < 100; i++)
			{
				auto str = meme::randomletters(meme::random(0, 10));
				instance.SetLettersOnly(str);
				Assert::AreEqual(str, instance.GetLettersOnly(), L"incorrect set letters value (valid input)");
			}

			for (int i = 0; i < 100; i++)
			{
				auto str = meme::randomothers(meme::random(0, 10));
				instance.SetLettersOnly(str);
				Assert::AreEqual(std::string(""), instance.GetLettersOnly(), L"incorrect set letters value (invalid input)");
			}
			for (int i = 0; i < 500; i += 5)
			{
				instance.SetSomeData(i);
				if (i < 100)
					Assert::IsTrue(instance.GetCorrectedData() == i, L"Input has not been set properly. (mismatch");
				Assert::IsTrue(instance.GetCorrectedData() <= 100, L"Input has not been corrected properly. (over 100)");
				Assert::IsTrue(instance.GetCorrectedData() >= 0, L"Input has not been corrected properly. (less than 0)");
			}
		}
	};
}
