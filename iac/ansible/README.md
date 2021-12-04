## info sources
```
https://kubernetes.io/blog/2019/03/15/kubernetes-setup-using-ansible-and-vagrant/
#https://learn.hashicorp.com/collections/vagrant/getting-started
#https://www.theurbanpenguin.com/provisioning-vagrant-with-ansible/
https://projectcalico.docs.tigera.io/getting-started/kubernetes/quickstart
```
## k8s commands
```
#https://kubernetes.io/ru/docs/reference/kubectl/cheatsheet/
kubectl config get-contexts
kubectl config use-context 
kubectl config delete-context 
kubectl config unset users.gke_project_zone_name
kubectl config unset contexts.aws_cluster1-kubernetes
kubectl config unset clusters.foobar-baz
```
## ansible commands
```  
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

    ansible-playbook -i inventory -v pb_install_cluster.yml
```
## vagrant commands
```
    sudo vagrant up    
    sudo vagrant ssh k8s-master
    sudo vagrant destroy --force
```

## regex
```
    https://regex101.com/
    https://question-it.com/questions/2028065/ansible-lineinfile-izmenit-stroku      
``` 
## git commands
```
    ssh -vT git@github.com   
    git remote set-url origin git@github.com:mihsta/reponame.git   
    git log --all --oneline --graph --decorate  
    git checkout env  
    git checkout main  
    git tag
    git push --tags
    git submodule init 
```