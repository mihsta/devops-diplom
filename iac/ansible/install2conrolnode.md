## CONTROL_NODE: install ansible
```
sudo apt update && apt upgrade -y
sudo apt-add-repository ppa:ansible/ansible
sudo apt install ansible
ansible --version
#sudo apt-get install -y python-pip libssl-dev
```
## CLUSTER_NODE: install os
## CLUSTER_NODE: install ssh
sudo apt update
sudo apt install openssh-server
sudo systemctl status ssh
sudo ufw allow ssh

## CLUSTER_NODE: add ansible user sudoers
sudo adduser ansible
sudo echo "ansible ALL=(ALL) NOPASSWD:ALL" > /etc/sudoers.d/ansible

## CONTROL_NODE: create envvar sshhost
export SSH_HOST=ansible@ipaddress


## CONTROL_NODE: create user ansible envvar sshhost & copy pub key
sudo adduser ansible
ssh-keygen -q -N "" -f /home/ansible/.ssh/id_rsa <<<y >/dev/null 2>&1  
sudo ssh-copy-id -i /home/ansible/.ssh/id_rsa.pub $SSH_HOST -f

## CONTROL_NODE: create envvar sshhost
su ansible
ssh $SSH_HOST



