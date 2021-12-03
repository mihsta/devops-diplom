## ansible commands  
    ansible --version
    ansible all -i inventory --list-hosts -v
    nano /etc/ansible/ansible.cfg
    ansible -m ping all
    ansible-doc -l
    ansible-doc package
    ansible-doc -s package
    ansible-playbook -v playbook.yml
    ansible-vault encrypt_string "PassAlice" --name "pass" --vault-password-file .ansible_pass
    ansible-playbook pb_creating.yml --vault-password-file .ansible_pass  -v

## regex
    https://regex101.com/
    https://question-it.com/questions/2028065/ansible-lineinfile-izmenit-stroku      
    
## git commands
    ssh -vT git@github.com
    git clone git@github.com:mihsta/ansible_lab.git 
    git remote set-url origin git@github.com:mihsta/ansible_lab.git   
    git log --all --oneline --graph --decorate  
    git checkout env  
    git checkout main  
    git tag
    git push --tags
    git submodule init 