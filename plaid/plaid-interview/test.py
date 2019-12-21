import itertools
import operator


def main():
    list1 = [
        ("Netflix", 9.99, 10),
        ("Netflix", 9.99, 20),
        ("Netflix", 9.99, 30),
        ("Amazon", 27.12, 32),
        ("Amazon", 27.12, 33),
        ("Amazon", 27.12, 34),
        ("Netflix", 9.99, 40),
        ("Sprint", 50.11, 45),
        ("Sprint", 50.11, 55),
        ("Sprint", 50.11, 65),
        # ("Sprint", 60.13, 77),
    ]

    print(recurring_list(list1))

def recurring_list(_list):
    d = {l[0]: [] for l in _list}
    for l in _list:

        # {
        #     "Netflix": {curr_value: 9.99, curr_time: 10, count: 0, difference: number}
        # }

        # dict holds last seen value for a description, and the count
        # add key to dict if it doesn't exist already
        # check the current value against the previous value, if it's there
        # if l[0] in d
        d[l[0]].append((l[1], l[2]))

    ret = []
    for key,value in d.items():
        # check if all amounts are same
        # check if all timestamps are same distance
        # check if there are at least 3 values
        same_value = True
        same_difference = True
        count = 0
        if len(value) < 3:
            continue
        curr_value = value[0][0]
        curr_time = value[0][1]
        difference = value[1][1] - value[0][1]
        iter_count = 0
        for v in value:
            if iter_count != 0:
                if (v[0] != curr_value):
                    same_value = False
                    continue
                if (v[1] - curr_time) != difference:
                    same_difference = False
                    continue
                count += 1
                curr_value = v[0]
                curr_time = v[1]
            iter_count += 1
        
        if count >= 2 and same_value and same_difference:
            ret.append(key)
    return ret

# this is an idea for the improved version
def recurring_list2(_list):
    d = {l[0]: [] for l in _list}
    for l in _list:

        # {
        #     "Netflix": {curr_value: 9.99, curr_time: 10, count: 0, difference: number}
        # }

        # dict holds last seen value for a description, and the count
        # add key to dict if it doesn't exist already
        # check the current value against the previous value, if it's there
        # if l[0] in d:

        # elif: 

        d[l[0]].append((l[1], l[2]))

    ret = []
    for key,value in d.items():
        # check if all amounts are same
        # check if all timestamps are same distance
        # check if there are at least 3 values
        same_value = True
        same_difference = True
        count = 0
        if len(value) < 3:
            continue
        curr_value = value[0][0]
        curr_time = value[0][1]
        difference = value[1][1] - value[0][1]
        iter_count = 0
        for v in value:
            if iter_count != 0:
                if (v[0] != curr_value):
                    same_value = False
                    continue
                if (v[1] - curr_time) != difference:
                    same_difference = False
                    continue
                count += 1
                curr_value = v[0]
                curr_time = v[1]
            iter_count += 1
        
        if count >= 2 and same_value and same_difference:
            ret.append(key)
    return ret

if __name__ == "__main__":
    main()
