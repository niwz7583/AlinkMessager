AilinkMessager V1.0.6047 修改说明(2016-07-22)
1、增加弹屏调用时的键名设置，具体为：
ActionFieldCaller => 主叫号码  
ActionFieldCalled => 被叫号码
ActionFieldTrunk => 中继号码
ActionFieldGuid = > 唯一编号
2、修正CTI服务停止后，客户端不断开的缺陷；
3、增加通话小结功能（注：此功能需要设置CTI数据库的连接后方可，具体为config文件中的CTIConnectString字段）；



AilinkMessager软外拨方法调用说明

1、手动软外拨，可以通过状态栏右键菜中的“软外拨”功能进行；
2、基于Http方式的软外拨，通过调用本地Url的方式进行，具体路径如下：
http://127.0.0.1:8089/?flag=lxkj123-=&action=dialup&phoneno=057156788567&autodial=true
其中参数说明：
1)flag：调用标志，对非法调用稍做控制；
2)action：调用的方法，软外拨时请传dialup；(注：目前支持"login", "logout", "setdnd", "setundnd", "dialup"五个，分别代表签入、签出、置忙、置闲、软外拨）
3)phoneno：需要外拨的号码(不需添加出局号)；
4)autodial：是否自动拨号，如果为true，则直接进行拨号；其它则弹出软外拨界面；


3、返回数据说明： 返回数据为JSON格式的数据，类似于：{"statusCode":200 ,"message": "10003"}
其中statusCode为状态代码，statusCode为200时表示调用成功，message返回的是相应操作的编号，如action为dialup时，则返回呼叫编号，后续可以通过该编号进行状态的查询；
其余的statusCode均为异常情况，message中显示为相应的提示信息；




				杭州领先科技有限公司
                                    2015.01.31