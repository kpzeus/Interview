class Solution {
public:
    int minFlips(int a, int b, int c) {
        std::string a1 = std::bitset<32>(a).to_string();
        std::string b1 = std::bitset<32>(b).to_string();
        std::string c1 = std::bitset<32>(c).to_string();

        int i=0;
        int count=0;
        while (i < 32){
            if(c1[i] == '1'){
                if(a1[i] != '1' && b1[i] != '1')
                    count++;
            }
            else{
                if(a1[i] == '1')
                    count++;
                if(b1[i] == '1')
                    count++;
            }
            i++;
        }

        return count;
    }
};