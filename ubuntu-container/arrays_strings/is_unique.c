#include <stdio.h>
#include <stdbool.h>
#include <string.h>

bool all_unique(char *s);
// main function -
// where the execution of program begins
int main()
{
  // prints hello world
  printf("Hello world \n");
  all_unique("Test string");
  all_unique("asdfgh");
  return 0;
}

// using brute force.
bool all_unique(char *s)
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