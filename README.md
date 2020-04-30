# Sample: nginx-https-wcf-websockets

采用nginx反向代理实现(http/https)：    
- [x] WCF服务器
- [x] Websocket服务器
- [x] SignalR服务器
- [x] IIS服务器
- [ ] 其它


:point_right:[Emojo quick link](https://www.webfx.com/tools/emoji-cheat-sheet/)



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
