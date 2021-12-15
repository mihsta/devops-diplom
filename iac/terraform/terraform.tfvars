#https://www.terraform.io/docs/cli/config/environment-variables.html
# az ad sp create-for-rbac --name "terraform_diplomapp" --skip-assignment
#  "displayName": "terraform_diplomapp",
appId=$(TF_VAR_appId)
password=$(TF_VAR_password)