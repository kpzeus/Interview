/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
class Solution {
public:
    bool leafSimilar(TreeNode* root1, TreeNode* root2) {
        vector<int> r1 = GetLeaves(root1);
        vector<int> r2 = GetLeaves(root2);
        //cout<<"s"<<r1.size()<<'\n';
        if(r1.size() != r2.size())
            return false;
        
        int i=0;
        while(i < r1.size()){
            //cout<<'\n'<<r1[i]<<r2[i];
            if(r1[i] != r2[i])
                return false;
            i++;
        }

        return true;
    }

    vector<int> GetLeaves(TreeNode* root){
        vector<int> l;
        Visit(root,l);
        return l;
    }

    void Visit(TreeNode* root,  vector<int>& l){
        if(root == NULL)
            return;

        if(root->left == NULL && root->right == NULL){
            l.push_back(root->val);
            //cout<<"val"<<root->val<<'\n';
            //for (auto elem : l) {
            //    cout<<"l"<<elem<<'\n';
            //}
        }

        Visit(root->left, l);
        Visit(root->right, l);
    }
};