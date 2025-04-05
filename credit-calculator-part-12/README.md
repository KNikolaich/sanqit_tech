"# credit-calculator" 

Создание pfx из pem файлов

openssl pkcs12 -export -in fullchain.pem -inkey privkey.pem -out [name.pfx]
создать зашифрованый key файл из pfx
openssl pkcs12 -in [name.pfx] -nocerts -out [keyfile-encrypted.key]
создать расшифрованный key файл из pfx
openssl rsa -in [keyfile-encrypted.key] -out [name.key]
получить cer из pfx
openssl pkcs12 -in [name.pfx] -clcerts -nokeys -out [name.crt]