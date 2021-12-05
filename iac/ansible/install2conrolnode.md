## CONTROL_NODE: install ansible (1m)
```
sudo apt update && apt upgrade -y
sudo apt-add-repository ppa:ansible/ansible
sudo apt install ansible
ansible --version
```
## CLUSTER_NODE: install os (10m)
```
ubuntu 20.04
secureboot disable (cos needs drivers key for vbox)
make sure use uefi on boot devices and not use encription not disks. So many troubleshooting
```
## CLUSTER_NODE: install ssh & vbox, add ansible user (5m)
```
sudo apt update
sudo apt install openssh-server
sudo systemctl status ssh
sudo ufw allow ssh
sudo apt install virtualbox

sudo adduser ansible
sudo echo "ansible ALL=(ALL) NOPASSWD: ALL" > /etc/sudoers.d/ansible
```
## fix if ssh Authentication refused: bad ownership or modes for directory
```
sudo chmod go-w ~/
sudo chmod 700 ~/.ssh
sudo chmod 600 ~/.ssh/authorized_keys
```
## CONTROL_NODE: create user ansible envvar sshhost & copy pub key (1m)
```
export SSH_CLUSTER_HOST=ansible@ipaddress
sudo adduser ansible
ssh-keygen -q -N "" -f /home/ansible/.ssh/id_rsa <<<y >/dev/null 2>&1  
sudo ssh-copy-id -i /home/ansible/.ssh/id_rsa.pub $SSH_CLUSTER_HOST -f
```
## CONTROL_NODE: create envvar sshhost test connect (1m)
```
su ansible
ssh $SSH_CLUSTER_HOST
```
## CONTROL_NODE: install k8s (20m)
```
ansible-playbook -i inventory -v pb_install_cluster.yml
```

## CLUSTER_NODE: copy /home/vagrant/.kube/config (2m)
```
#gotovmk8smaster
sudo vagrant ssh k8s-master 
nano /home/vagrant/.kube/config #copy2buffer
#backtovmhost
exit 
mkdir -p /home/ansible/.kube
nano /home/ansible/.kube/config #paste config
chown ansible:ansible /home/ansible/.kube/config
kubectl config view
```

# CLUSTER_NODE Troubleshooting
## reset cluster (k8s-master vm)
```
    sudo kubeadm reset --force
    rm -rf .kube/
    sudo rm -rf /etc/kubernetes/
    sudo rm -rf /var/lib/kubelet/
    sudo rm -rf /var/lib/etcd
```
