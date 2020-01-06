#include <string>
#include <regex>

class TestClass2
{
private:
	int SomeData = 0;
	std::string LettersOnly = "";

public:
	TestClass2()
	{

	}

	std::string GetLettersOnly() {
		return LettersOnly;
	}
	void SetLettersOnly(std::string LettersOnlyInput)
	{
		if (std::regex_match(LettersOnlyInput, std::regex("^[A-Za-z]+$")))
			LettersOnly = LettersOnlyInput;
		else
			LettersOnly = "";
	}

	int GetCorrectedData()
	{
		if (SomeData > 100)
			return 100;
		else if (SomeData < 0)
			return 0;
		else return SomeData;
	}
	void SetSomeData(int data) {
		SomeData = data;
	}
};