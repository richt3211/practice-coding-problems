#include <iostream>

using namespace std;

bool all_unique(std::string s);
// main function -
// where the execution of program begins
int main()
{
    // prints hello world
    cout << "Hello World" << std::endl;
    all_unique("Test string");
    all_unique("asdfgh");
    return 0;
}

// using brute force. 
bool all_unique(std::string s)
{
    std::cout << "Testing string: " << s << std::endl;
    bool is_unique = true;
    for (std::string::size_type i = 0; i < s.size(); i++)
    {
        for (std::string::size_type j = 0; j < s.size(); j++)
        {
            if (s[i] == s[j] && i != j)
            {
                is_unique = false;
            }
        }
    }
    std::cout << "Result is: " << (is_unique ? "True" : "False") << std::endl;
    return is_unique;
}