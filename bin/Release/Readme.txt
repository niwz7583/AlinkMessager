AilinkMessager V1.0.6667  �޸�˵��(2018-04-03)
1�����ӵ�¼ʱ����URLҳ�������������ļ��������ֶ�LoginPageUrl��ֵΪĿ��URL��ַ���ɣ���δ�����򲻵��ã�
����ֶ�Ϊ:
LoginFieldAgent		��ϯ��
LoginFieldEmployee	Ա����


AilinkMessager V1.0.6661  �޸�˵��(2018-03-28)
1����������״̬������ȱ�ݣ�
2��������·����guid�а�����������ʱ���в�֣��Ա�֤guid����ȷ�ԣ�
3�����ӵ�������ʱ�ļ���ActionFieldEmployee����Ӧ��ǰ��Ա���ţ�
4����ʽ����������URL·����

AilinkMessager V1.0.6655   �޸�˵��(2018-03-13)
1��������ʾ���������ӵ绰����ϯ��Ϣ(�����ò���:����:QueueCount����ʾģʽ:QueueMode[1:��ϯ��_Ա����;2:��ϯ��;3:Ա����]����ʾ��ǩ:QueueTitle)������Ϣͨ��������ʽչʾ��
2����������ͨ�����ܣ�֧�ֶ�ͨ�������еĺ������"����/ȡ������"������
3�������������ϵ��Ҽ��˵���
4��������ת�ӡ��˵�״̬�л���ʱ����ȷ��ȱ�ݣ�
5�����ӡ�Ա���š�����������ǩ��ʱ����ʹ�ò�ͬ����ϯ�ŵ�Ա���ţ�
6�����Ӳ��š�ת�ӡ�����ͨ��ʱ������Զ���ȫ���ܣ�


AilinkMessager V1.0.6142 �޸�˵��(2016-10-25)
1������������븴�ƹ��ܣ�

AilinkMessager V1.0.6066 �޸�˵��(2016-08-10)
1������ת�ӹ��ܣ�

AilinkMessager V1.0.6047 �޸�˵��(2016-07-22)
1�����ӵ�������ʱ�ļ������ã�����Ϊ��
ActionFieldCaller => ���к���  
ActionFieldCalled => ���к���
ActionFieldTrunk => �м̺���
ActionFieldGuid = > Ψһ���
2������CTI����ֹͣ�󣬿ͻ��˲��Ͽ���ȱ�ݣ�
3������ͨ��С�Ṧ�ܣ�ע���˹�����Ҫ����CTI���ݿ�����Ӻ󷽿ɣ�����Ϊconfig�ļ��е�CTIConnectString�ֶΣ���



AilinkMessager���Ⲧ��������˵��

1���ֶ����Ⲧ������ͨ��״̬���Ҽ����еġ����Ⲧ�����ܽ��У�
2������Http��ʽ�����Ⲧ��ͨ�����ñ���Url�ķ�ʽ���У�����·�����£�
http://127.0.0.1:8089/?flag=lxkj123-=&action=dialup&phoneno=057156788567&autodial=true
���в���˵����
1)flag�����ñ�־���ԷǷ������������ƣ�
2)action�����õķ��������Ⲧʱ�봫dialup��(ע��Ŀǰ֧��"login", "logout", "setdnd", "setundnd", "dialup"������ֱ����ǩ�롢ǩ������æ�����С����Ⲧ��
3)phoneno����Ҫ�Ⲧ�ĺ���(������ӳ��ֺ�)��
4)autodial���Ƿ��Զ����ţ����Ϊtrue����ֱ�ӽ��в��ţ������򵯳����Ⲧ���棻


3����������˵���� ��������ΪJSON��ʽ�����ݣ������ڣ�{"statusCode":200 ,"message": "10003"}
����statusCodeΪ״̬���룬statusCodeΪ200ʱ��ʾ���óɹ���message���ص�����Ӧ�����ı�ţ���actionΪdialupʱ���򷵻غ��б�ţ���������ͨ���ñ�Ž���״̬�Ĳ�ѯ��
�����statusCode��Ϊ�쳣�����message����ʾΪ��Ӧ����ʾ��Ϣ��


AilinkMessagerϵͳ����˵��
�������þ���AlinkMessager.exe.config�ļ��У���������˵�����£�

CTIAddress	AilinkServer��IP��ַ
CTIPort		AilinkServer�˵Ķ˿ں�

AgentNo		�ֻ���
EmployeeNo	Ա����
AgentPwd	Ա������

ActionPageUrl	���絯��ִ�е����������url��Ҳ���Գ���ϵͳ���Զ��滻�������ݣ�
ActionFieldCaller 	���к���  
ActionFieldCalled	���к���
ActionFieldTrunk	�м̺���
ActionFieldGuid		Ψһ���

CTIConnectString	CTI���ݿ����Ӵ�������ͨ��С���ת�Ӻ������ݵĻ�ȡ��

HttpActionPort	���������˿ںţ�����http����֧�֣�Ĭ��Ϊ8089��
AutoLogin	�Ƿ��Զ�ǩ�룻
AutoRun		�Ƿ��Զ����У�
FirstCodeList	���ֺ��б�
FirstCode	���ֺ�

QueueCount	��������
QueueMode	������ʾģʽ��1:��ϯ��_Ա����;2:��ϯ��;3:Ա���ţ�Ĭ��Ϊ1��
QueueTitle	������ʾ���⣬Ĭ��Ϊ"�Ӵ�Ա����"






				�������ȿƼ����޹�˾
                                    2015.01.31