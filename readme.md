
**Note**
BookApi 和 PassengerApi 分别为两个Api项目，ApiGateway 时网关项目

**使用步骤**

1. 启动三个项目。
2. 访问BookApi，http://localhost:8001/index.html 查看并访问相关接口
3. 访问PassengerApi，http://localhost:8002/index.html 查看并访问相关接口
4. 通过网关访问：http://localhost:5000/api/getbook 等接口都可访问
   具体可一查看网关项目下的配置文件（configuration.json）
