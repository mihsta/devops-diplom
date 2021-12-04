https://kubernetes.io/blog/2019/03/15/kubernetes-setup-using-ansible-and-vagrant/
#https://learn.hashicorp.com/collections/vagrant/getting-started
#https://www.theurbanpenguin.com/provisioning-vagrant-with-ansible/
https://projectcalico.docs.tigera.io/getting-started/kubernetes/quickstart

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

    ansible-playbook -i inventory -v pb_install_cluster.yml
## vagrant commands
    sudo vagrant up
    
    sudo vagrant ssh k8s-master

    vagrant reload 
    vagrant destroy --force

## reset cluster 
    sudo kubeadm reset --force
    rm -rf .kube/
    sudo rm -rf /etc/kubernetes/
    sudo rm -rf /var/lib/kubelet/
    sudo rm -rf /var/lib/etcd

# docker daemon config for systemd from cgroupfs & restart 
sudo cat <<EOF > /etc/docker/daemon.json
{
  "exec-opts": ["native.cgroupdriver=systemd"]
}
EOF
sudo systemctl daemon-reload && systemctl restart docker

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