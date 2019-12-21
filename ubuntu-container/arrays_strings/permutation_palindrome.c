#include <stdio.h>
#include <stdbool.h>
#include <string.h>

bool permutation_palindrome(char *s);
// main function -
// where the execution of program begins
int main()
{
  permutation_palindrome("Test string");
  permutation_palindrome("asdfgh");
  return 0;
}

// using brute force.
bool permutation_palindrome(char *s)
{
  printf("Testing string: %s \n", s);
  
  bool is_unique = true;
  for (int i = 0; i < strlen(s); i++)
  {
    for (int j = 0; j < strlen(s); j++)
    {
      if (s[i] == s[j] && i != j)
      {
        is_unique = false;
      }
    }
  }
  char* result = is_unique ? "True" : "False";
  printf("Result is: %s \n", result);
  return is_unique;
}