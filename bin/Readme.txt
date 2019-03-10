AilinkMessager V1.0.6667  修改说明(2018-04-03)
1、增加登录时启动URL页，具体在配置文件中设置字段LoginPageUrl的值为目标URL地址即可，如未设置则不调用；
相关字段为:
LoginFieldAgent		座席号
LoginFieldEmployee	员工号


AilinkMessager V1.0.6661  修改说明(2018-03-28)
1、修正滚动状态会跳的缺陷；
2、修正随路数据guid中包含其它数据时进行拆分，以保证guid的正确性；
3、增加弹屏调用时的键名ActionFieldEmployee，对应当前的员工号；
4、格式化弹屏调用URL路径；

AilinkMessager V1.0.6655   修改说明(2018-03-13)
1、增加显示后续三个接电话的座席信息(可配置参数:个数:QueueCount、显示模式:QueueMode[1:座席号_员工号;2:座席号;3:员工号]、显示标签:QueueTitle)，该信息通道滚动方式展示。
2、增加三方通话功能，支持对通话过程中的号码进行"静音/取消静音"操作；
3、增加主界面上的右键菜单；
4、修正“转接”菜单状态切换有时不正确的缺陷；
5、增加“员工号”参数，用于签入时可以使用不同于座席号的员工号；
6、增加拨号、转接、三方通话时号码的自动补全功能；


AilinkMessager V1.0.6142 修改说明(2016-10-25)
1、增加来电号码复制功能；

AilinkMessager V1.0.6066 修改说明(2016-08-10)
1、增加转接功能；

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


AilinkMessager系统参数说明
具体配置均在AlinkMessager.exe.config文件中，基础参数说明如下：

CTIAddress	AilinkServer端IP地址
CTIPort		AilinkServer端的端口号

AgentNo		分机号
EmployeeNo	员工号
AgentPwd	员工密码

ActionPageUrl	来电弹屏执行的命令，可以是url，也可以程序，系统会自动替换参数内容；
ActionFieldCaller 	主叫号码  
ActionFieldCalled	被叫号码
ActionFieldTrunk	中继号码
ActionFieldGuid		唯一编号

CTIConnectString	CTI数据库连接串，用于通话小结和转接号码数据的获取；

HttpActionPort	本地侦听端口号，用于http调用支持，默认为8089；
AutoLogin	是否自动签入；
AutoRun		是否自动运行；
FirstCodeList	出局号列表
FirstCode	出局号

QueueCount	队列数量
QueueMode	队列显示模式，1:座席号_员工号;2:座席号;3:员工号，默认为1；
QueueTitle	队列显示标题，默认为"接待员工："






				杭州领先科技有限公司
                                    2015.01.31