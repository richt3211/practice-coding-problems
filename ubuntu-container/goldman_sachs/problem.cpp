#include <bits/stdc++.h>

using namespace std;

string ltrim(const string &);
string rtrim(const string &);
vector<string> split(const string &);

int rankIndex(vector<vector<int>> values, int rank) {
  vector<int> total(values[0].size(), 0);
  for (vector<int> value :values)
  {
    for (int i = 0; i < value.size(); i++)
    {
      total[i] += value[i];
    }
  }
  sort(total.begin(), total.end());
  return total[rank];
}

int main()
{
    ofstream fout(getenv("OUTPUT_PATH"));

    string values_rows_temp;
    getline(cin, values_rows_temp);

    int values_rows = stoi(ltrim(rtrim(values_rows_temp)));

    string values_columns_temp;
    getline(cin, values_columns_temp);

    int values_columns = stoi(ltrim(rtrim(values_columns_temp)));

    vector<vector<int>> values(values_rows);

    for (int i = 0; i < values_rows; i++) {
        values[i].resize(values_columns);

        string values_row_temp_temp;
        getline(cin, values_row_temp_temp);

        vector<string> values_row_temp = split(rtrim(values_row_temp_temp));

        for (int j = 0; j < values_columns; j++) {
            int values_row_item = stoi(values_row_temp[j]);

            values[i][j] = values_row_item;
        }
    }

    string rank_temp;
    getline(cin, rank_temp);

    int rank = stoi(ltrim(rtrim(rank_temp)));

    int result = rankIndex(values, rank);

    fout << result << "\n";

    fout.close();

    return 0;
}

string ltrim(const string &str) {
    string s(str);

    s.erase(
        s.begin(),
        find_if(s.begin(), s.end(), not1(ptr_fun<int, int>(isspace)))
    );

    return s;
}

string rtrim(const string &str) {
    string s(str);

    s.erase(
        find_if(s.rbegin(), s.rend(), not1(ptr_fun<int, int>(isspace))).base(),
        s.end()
    );

    return s;
}

vector<string> split(const string &str) {
    vector<string> tokens;

    string::size_type start = 0;
    string::size_type end = 0;

    while ((end = str.find(" ", start)) != string::npos) {
        tokens.push_back(str.substr(start, end - start));

        start = end + 1;
    }

    tokens.push_back(str.substr(start));

    return tokens;
}