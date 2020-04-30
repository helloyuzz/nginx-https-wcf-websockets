# Sample: nginx-https-wcf-websockets

采用nginx反向代理实现(http/https)：    
- [x] WCF服务器
- [x] Websocket服务器
- [x] SignalR服务器
- [x] IIS服务器
- [ ] 其它


:point_right:[Emojo quick link](https://www.webfx.com/tools/emoji-cheat-sheet/)  
:a:[read more](https://github.com/ikatyang/emoji-cheat-sheet/blob/master/README.md)


**1.MakeCert自签名根证书**
```
makecert -r -pe -n "CN=1TYU Root Certificate" -sv 1TYU_ROOT.pvk 1TYU_ROOT.cer
```

**2.示例域名(github.1tyu.cc)**
```
makecert -n "CN=github.1tyu.cc" -pe -iv 1TYU_ROOT.pvk -ic 1TYU_ROOT.cer -sky exchange -ss My
```
 然后从证书管理器中导出证书，pfx文件名：github.1tyu.cc.pfx  

**3.OPENSSL 导出crt及key文件，用于Nginx https配置**
```OPENSSL
openssl pkcs12 -in github.1tyu.cc.pfx -clcerts -nokeys -out github.1tyu.cc.crt - Export crt file
openssl pkcs12 -in github.1tyu.cc.pfx -nodes -out github.1tyu.cc.key - Export key file
```

**4.Nginx WSS Configration**
```
http{
    map $http_upgrade $connection_upgrade {
        default upgrade;
        '' close;
    }
    
    server {
        listen       8083 ssl;
        server_name  github.1tyu.cc;

        # 证书配置
        ssl_certificate      d:/github.1tyu.cc.crt;
        ssl_certificate_key  d:/github.1tyu.cc.key;
    
        ssl_session_cache    shared:SSL:1m;
        ssl_session_timeout  5m;
    
        ssl_ciphers  HIGH:!aNULL:!MD5;
        ssl_prefer_server_ciphers  on;

        #access_log  /var/log/nginx/websocket.access.log  main;

        location /wss {
            proxy_pass http://github.1tyu.cc:10011;            #指向wss服务器地址

            proxy_http_version 1.1;
            proxy_set_header Upgrade $http_upgrade;
            proxy_set_header Connection "upgrade";

            proxy_set_header X-Real-IP $remote_addr;            
            proxy_set_header Host $host;
            proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        }
}
```
