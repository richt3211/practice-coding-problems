#!/bin/python3

import math
import os
import random
import re
import sys



#
# Complete the 'rankIndex' function below.
#
# The function is expected to return an INTEGER.
# The function accepts following parameters:
#  1. 2D_INTEGER_ARRAY values
#  2. INTEGER rank
#

def rankIndex(values, rank):
    total = []
    for value in values:
      for i in range(len(value)):
        total[i] = value[i]
    total.sort()
    return total[rank]

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    values_rows = int(input().strip())
    values_columns = int(input().strip())

    values = []

    for _ in range(values_rows):
        values.append(list(map(int, input().rstrip().split())))

    rank = int(input().strip())

    result = rankIndex(values, rank)

    fptr.write(str(result) + '\n')

    fptr.close()
