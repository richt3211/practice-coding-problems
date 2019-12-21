#include <assert.h>
#include <limits.h>
#include <math.h>
#include <stdbool.h>
#include <stddef.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char* readline();
char** split_string(char*);

// Complete the minimumBribes function below.
void minimumBribes(int q_count, int* q) {
  int total_count = 0;
  int max = q[0];
  for (int i =0; i < q_count; i++)
  {
    int temp = q[i];
    if ((temp - (i + 1)) > 2)
    {
      printf("Too chaotic\n");
      return;
    }
    int gt_count = 0;
    // if are greater than max, we need to do the loop again. 
    if (temp > max) 
    {
      max = temp;
      for (int j =i +1; j < q_count; j++)
      {
        if (temp > q[j])
        {
          gt_count++;
        }
        if (gt_count == 2)
        {
          break;
        }
      }
    }
    else 
    {
      int difference = max - temp;
      if (gt_count == 2)
      {
        if (difference >= 2)
        {
          gt_count == 0;
        }
        else if (difference == 1)
        {
          gt_count = 1;
        }
      }
      else if (gt_count == 1)
      {
        gt_count = 0;
      }
    }
    total_count += gt_count;

  }
  printf("%d\n", total_count);
  return;

}

int main()
{
    char* t_endptr;
    char* t_str = readline();
    int t = strtol(t_str, &t_endptr, 10);

    if (t_endptr == t_str || *t_endptr != '\0') { exit(EXIT_FAILURE); }

    for (int t_itr = 0; t_itr < t; t_itr++) {
        char* n_endptr;
        char* n_str = readline();
        int n = strtol(n_str, &n_endptr, 10);

        if (n_endptr == n_str || *n_endptr != '\0') { exit(EXIT_FAILURE); }

        char** q_temp = split_string(readline());

        int* q = malloc(n * sizeof(int));

        for (int i = 0; i < n; i++) {
            char* q_item_endptr;
            char* q_item_str = *(q_temp + i);
            int q_item = strtol(q_item_str, &q_item_endptr, 10);

            if (q_item_endptr == q_item_str || *q_item_endptr != '\0') { exit(EXIT_FAILURE); }

            *(q + i) = q_item;
        }

        int q_count = n;

        minimumBribes(q_count, q);
    }

    return 0;
}

char* readline() {
    size_t alloc_length = 1024;
    size_t data_length = 0;
    char* data = malloc(alloc_length);

    while (true) {
        char* cursor = data + data_length;
        char* line = fgets(cursor, alloc_length - data_length, stdin);

        if (!line) { break; }

        data_length += strlen(cursor);

        if (data_length < alloc_length - 1 || data[data_length - 1] == '\n') { break; }

        size_t new_length = alloc_length << 1;
        data = realloc(data, new_length);

        if (!data) { break; }

        alloc_length = new_length;
    }

    if (data[data_length - 1] == '\n') {
        data[data_length - 1] = '\0';
    }

    data = realloc(data, data_length);

    return data;
}

char** split_string(char* str) {
    char** splits = NULL;
    char* token = strtok(str, " ");

    int spaces = 0;

    while (token) {
        splits = realloc(splits, sizeof(char*) * ++spaces);
        if (!splits) {
            return splits;
        }

        splits[spaces - 1] = token;

        token = strtok(NULL, " ");
    }

    return splits;
}