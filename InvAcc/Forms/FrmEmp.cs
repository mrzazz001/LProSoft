using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InputKey;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
//using InvAcc.Reports;
using Microsoft.VisualBasic;
//using Microsoft.VisualBasic.FileIO;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmEmp : Form
    { void avs(int arln)

{ 
 ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; groupBox8.Text=   (arln == 0 ? "  التذاكـــر  " : "  tickets") ; label68.Text=   (arln == 0 ? "  رصيد التذاكر :  " : "  Ticket Balance:") ; label65.Text=   (arln == 0 ? "  سعر التذكرة :  " : "  Ticket price :") ; label67.Text=   (arln == 0 ? "  تذاكر السنة :  " : "  Year tickets:") ; groupBox10.Text=   (arln == 0 ? "  الإجازات  " : "  holidays") ; label64.Text=   (arln == 0 ? "  رصيد الإجـــازات :  " : "  Leave balance:") ; label62.Text=   (arln == 0 ? "  يوم  " : "  day") ; label63.Text=   (arln == 0 ? "  الاجازة السنوية :  " : "  yearly vacation :") ; groupPanel15.Text=   (arln == 0 ? "  معطيات القيد المحاسبي التلقائي للراتب  " : "  Salary automatic accounting entry data") ; label116.Text=   (arln == 0 ? "  مركز التكلفــة :  " : "  cost center:") ; label17.Text=   (arln == 0 ? "  حساب السلف :  " : "  advance account:") ; label16.Text=   (arln == 0 ? "  حساب السكن :  " : "  Accommodation account:") ; label15.Text=   (arln == 0 ? "  حساب الراتب :  " : "  Salary Calculation:") ; itemPanel7.Text=   (arln == 0 ? "  itemPanel7  " : "  itemPanel7") ; groupPanel11.Text=   (arln == 0 ? "  الفترة الثانية  " : "  second period") ; label50.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label51.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label58.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; groupPanel12.Text=   (arln == 0 ? "  الفترة الاولى  " : "  The first period") ; label61.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label66.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label69.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; radioButton_FriBreakDay.Text=   (arln == 0 ? "  راحة  " : "  Comfort") ; radioButton_FriPeriods2.Text=   (arln == 0 ? "  فترتان  " : "  two terms") ; radioButton_FriPeriods1.Text=   (arln == 0 ? "  فتـــرة  " : "  period") ; itemPanel6.Text=   (arln == 0 ? "  itemPanel6  " : "  itemPanel6") ; groupPanel13.Text=   (arln == 0 ? "  الفترة الثانية  " : "  second period") ; label71.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label77.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label81.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; groupPanel14.Text=   (arln == 0 ? "  الفترة الاولى  " : "  The first period") ; label87.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label93.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label94.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; radioButton_ThurBreakDay.Text=   (arln == 0 ? "  راحة  " : "  Comfort") ; radioButton_ThurPeriods2.Text=   (arln == 0 ? "  فترتان  " : "  two terms") ; radioButton_ThurPeriods1.Text=   (arln == 0 ? "  فتـــرة  " : "  period") ; itemPanel5.Text=   (arln == 0 ? "  itemPanel5  " : "  itemPanel5") ; groupPanel9.Text=   (arln == 0 ? "  الفترة الثانية  " : "  second period") ; label44.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label45.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label46.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; groupPanel10.Text=   (arln == 0 ? "  الفترة الاولى  " : "  The first period") ; label47.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label48.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label49.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; radioButton_WenBreakDay.Text=   (arln == 0 ? "  راحة  " : "  Comfort") ; radioButton_WenPeriods2.Text=   (arln == 0 ? "  فترتان  " : "  two terms") ; radioButton_WenPeriods1.Text=   (arln == 0 ? "  فتـــرة  " : "  period") ; itemPanel4.Text=   (arln == 0 ? "  itemPanel4  " : "  itemPanel4") ; groupPanel7.Text=   (arln == 0 ? "  الفترة الثانية  " : "  second period") ; label35.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label37.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label39.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; groupPanel8.Text=   (arln == 0 ? "  الفترة الاولى  " : "  The first period") ; label41.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label42.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label43.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; radioButton_TusBreakDay.Text=   (arln == 0 ? "  راحة  " : "  Comfort") ; radioButton_TusPeriods2.Text=   (arln == 0 ? "  فترتان  " : "  two terms") ; radioButton_TusPeriods1.Text=   (arln == 0 ? "  فتـــرة  " : "  period") ; itemPanel3.Text=   (arln == 0 ? "  itemPanel3  " : "  itemPanel3") ; groupPanel5.Text=   (arln == 0 ? "  الفترة الثانية  " : "  second period") ; label29.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label30.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label31.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; groupPanel6.Text=   (arln == 0 ? "  الفترة الاولى  " : "  The first period") ; label32.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label33.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label34.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; radioButton_MonBreakDay.Text=   (arln == 0 ? "  راحة  " : "  Comfort") ; radioButton_MonPeriods2.Text=   (arln == 0 ? "  فترتان  " : "  two terms") ; radioButton_MonPeriods1.Text=   (arln == 0 ? "  فتـــرة  " : "  period") ; itemPanel2.Text=   (arln == 0 ? "  itemPanel2  " : "  itemPanel2") ; groupPanel3.Text=   (arln == 0 ? "  الفترة الثانية  " : "  second period") ; label23.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label24.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label25.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; groupPanel4.Text=   (arln == 0 ? "  الفترة الاولى  " : "  The first period") ; label26.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label27.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label28.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; radioButton_SunBreakDay.Text=   (arln == 0 ? "  راحة  " : "  Comfort") ; radioButton_SunPeriods2.Text=   (arln == 0 ? "  فترتان  " : "  two terms") ; radioButton_SunPeriods1.Text=   (arln == 0 ? "  فتـــرة  " : "  period") ; itemPanel1.Text=   (arln == 0 ? "  itemPanel1  " : "  itemPanel1") ; groupPanel2.Text=   (arln == 0 ? "  الفترة الثانية  " : "  second period") ; label20.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label21.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label22.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; groupPanel1.Text=   (arln == 0 ? "  الفترة الاولى  " : "  The first period") ; label19.Text=   (arln == 0 ? "  الانصراف :  " : "  Withdrawal:") ; label18.Text=   (arln == 0 ? "  حتى :  " : "  Until :") ; label14.Text=   (arln == 0 ? "  حضور :  " : "  Presence :") ; radioButton_SatBreakDay.Text=   (arln == 0 ? "  راحة  " : "  Comfort") ; radioButton_SatPeriods2.Text=   (arln == 0 ? "  فترتان  " : "  two terms") ; radioButton_SatPeriods1.Text=   (arln == 0 ? "  فتـــرة  " : "  period") ; labelX19.Text=   (arln == 0 ? "  This space intentionally left blank.  " : "  This space intentionally left blank.") ; superTabItem_Acc.Text=   (arln == 0 ? "  الحسـابات  " : "  Calculations") ; label11.Text=   (arln == 0 ? "  التأمينـــات المستحقة  " : "  Insurance payable") ; label130.Text=   (arln == 0 ? "  إحتساب المستحقات والمقطوعـــات من  :  " : "  Calculation of dues and lump sums from:") ; label80.Text=   (arln == 0 ? "  %  " : "  %") ; label78.Text=   (arln == 0 ? "  التأمين الطبـــــــي المدفوع من جهة العمل :  " : "  Medical insurance paid by the employer:") ; label79.Text=   (arln == 0 ? "  التأمين الإجتماعي المدفوع من جهة العمل :  " : "  Social insurance paid by the employer:") ; label74.Text=   (arln == 0 ? "  بــدلات أخــــرى :  " : "  Other suits:") ; label75.Text=   (arln == 0 ? "  بدل طبيعة عمل :  " : "  Work nature allowance:") ; label76.Text=   (arln == 0 ? "  بدل إعاشــــــــة :  " : "  Subsistence allowance:") ; label73.Text=   (arln == 0 ? "  بدل مواصلات :  " : "  Transportation allowance :") ; label72.Text=   (arln == 0 ? "  سكن / سنوياّ :  " : "  Accommodation / yearly:") ; label70.Text=   (arln == 0 ? "  راتب أساسي :  " : "  Basic salary :") ; line1.Text=   (arln == 0 ? "  line1  " : "  line1") ; label56.Text=   (arln == 0 ? "  تاريخ اخر تصفية :  " : "  Last filter date:") ; label53.Text=   (arln == 0 ? "  تاريخ التعـــــيين :  " : "  Appointment date:") ; label10.Text=   (arln == 0 ? "  المدير :  " : "  Manager :") ; groupBox4.Text=   (arln == 0 ? "  تــاريخ العقـــــد  " : "  Contract date") ; label54.Text=   (arln == 0 ? "  من :  " : "  From :") ; label55.Text=   (arln == 0 ? "  إلى :  " : "  to me :") ; label137.Text=   (arln == 0 ? "  شهر  " : "  Month") ; label140.Text=   (arln == 0 ? "  صرف بدل السكن كل :  " : "  Housing allowance is paid every:") ; label60.Text=   (arln == 0 ? "  عدد الأيام في الشهر :  " : "  Number of days in a month:") ; label59.Text=   (arln == 0 ? "  ساعات العمل :  " : "  work hours :") ; label57.Text=   (arln == 0 ? "  نوع العقـــد :  " : "  Contract type:") ; groupBox5.Text=   (arln == 0 ? "  حالة الــــراتب  " : "  salary status") ; groupBox6.Text=   (arln == 0 ? "  المستقطعـــات ( الخصومات )  " : "  Deductions (Deductions)") ; label86.Text=   (arln == 0 ? "  %  " : "  %") ; label84.Text=   (arln == 0 ? "  التأمين الطبي :  " : "  Medical Insurance :") ; label82.Text=   (arln == 0 ? "  التأمين الإجتماعي :  " : "  social Security :") ; label83.Text=   (arln == 0 ? "  خصم ساعة :  " : "  watch discount:") ; label85.Text=   (arln == 0 ? "  خصم يوم :  " : "  day discount:") ; groupBox7.Text=   (arln == 0 ? "  المستحقات ( الإضافي )  " : "  Receivables (additional)") ; label89.Text=   (arln == 0 ? "  إنتداب سفر :  " : "  travel assignment:") ; label90.Text=   (arln == 0 ? "  ساعــــــــة :  " : "  hour:") ; label91.Text=   (arln == 0 ? "  إضافي يوم :  " : "  extra day:") ; textBox_WorkNo.Text=   (arln == 0 ? "  مكتب العمل  " : "  Labour Office") ; checkBox_AutoReturnContr.Text=   (arln == 0 ? "  تجديد تلقائي  " : "  auto renewal") ; labelX18.Text=   (arln == 0 ? "  This space intentionally left blank.  " : "  This space intentionally left blank.") ; superTabItem_Contract.Text=   (arln == 0 ? "  العقــــــــد  " : "  the contract") ; textBox_SocialInsuranceNo.Text=   (arln == 0 ? "  : التأمين الإجتماعي  " : "  : social Security") ; label127.Text=   (arln == 0 ? "  الخبـــــــــــــرات :  " : "  Experiences:") ; label133.Text=   (arln == 0 ? "  المؤهل العلمي :  " : "  Qualification :") ; label125.Text=   (arln == 0 ? "  البريد الإلكتروني :  " : "  E-mail :") ; label124.Text=   (arln == 0 ? "  الجــــــــــــــوال :  " : "  Mobile:") ; label9.Text=   (arln == 0 ? "  المدينة :  " : "  City :") ; label126.Text=   (arln == 0 ? "  العنـــــــــــــوان :  " : "  Address:") ; label119.Text=   (arln == 0 ? "  تاريـخ الميــــلاد :  " : "  Birth date:") ; label118.Text=   (arln == 0 ? "  الحالة الإجتماعية :  " : "  Social status :") ; label117.Text=   (arln == 0 ? "  مكان الميـــــــلاد :  " : "  Birthplace:") ; label115.Text=   (arln == 0 ? "  فصيلة الدم :  " : "  blood type :") ; label114.Text=   (arln == 0 ? "  الجنــــــــــــس :  " : "  Gender:") ; label113.Text=   (arln == 0 ? "  الديانة :  " : "  Religion :") ; labelX1.Text=   (arln == 0 ? "  صورة الموظف  " : "  employee picture") ; label5.Text=   (arln == 0 ? "  الجنسيـــــــــــــة :  " : "  Nationality:") ; label4.Text=   (arln == 0 ? "  إســـــــم الكفيل :  " : "  Sponsor's name:") ; label3.Text=   (arln == 0 ? "  إســـــم الوظيفة :  " : "  Job name:") ; label2.Text=   (arln == 0 ? "  إســــــم القسم :  " : "  Department name:") ; label12.Text=   (arln == 0 ? "  إســــــــم الإدارة :  " : "  Administration name:") ; label52.Text=   (arln == 0 ? "  كلمة سر الموظف :  " : "  Employee password:") ; label40.Text=   (arln == 0 ? "  الإسم الإنجليزي :  " : "  English name:") ; label36.Text=   (arln == 0 ? "  الإسم العــــربي :  " : "  Arabic name:") ; label38.Text=   (arln == 0 ? "  الرقـــــــــــــــــم :  " : "  Number:") ; groupBox2.Text=   (arln == 0 ? "  التأمين الإجتماعي  " : "  social Security") ; label1.Text=   (arln == 0 ? "  %  " : "  %") ; label6.Text=   (arln == 0 ? "  %  " : "  %") ; label7.Text=   (arln == 0 ? "  مستحق من الشركة :  " : "  Due from the company:") ; label8.Text=   (arln == 0 ? "  يخصــــــم من الراتب :  " : "  Deducted from salary:") ; linkLabel_ChangeEmpNo.Text=   (arln == 0 ? "  تغـيير  " : "  change") ; labelX15.Text=   (arln == 0 ? "  This space intentionally left blank.  " : "  This space intentionally left blank.") ; superTabItem_Gen.Text=   (arln == 0 ? "  عــــــــــام  " : "  general") ; label121.Text=   (arln == 0 ? "  الفئــــــــــــة :  " : "  Category:") ; label120.Text=   (arln == 0 ? "  شركة التأمين الصحي :  " : "  Health insurance company:") ; button_SaveFamily.Text=   (arln == 0 ? "  حفظ المرافقين  " : "  save escorts") ; label122.Text=   (arln == 0 ? "  تاريخ الإنتهاء  " : "  Expiry date") ; label123.Text=   (arln == 0 ? "  جواز السفر  " : "  passport") ; label128.Text=   (arln == 0 ? "  الصلــــة  " : "  the connection") ; label129.Text=   (arln == 0 ? "  تاريخ الميلاد  " : "  Date of Birth") ; label132.Text=   (arln == 0 ? "  إسم المـــــرافق  " : "  escort name") ; superTabItem_Family.Text=   (arln == 0 ? "  المرافقــين  " : "  escorts") ; line2.Text=   (arln == 0 ? "  line2  " : "  line2") ; groupBox14.Text=   (arln == 0 ? "  تأشيرة الإستقدام  " : "  Recruitment visa") ; label136.Text=   (arln == 0 ? "  المنفذ :  " : "  Port:") ; label135.Text=   (arln == 0 ? "  تاريخ الدخول :  " : "  Date of entry :") ; label134.Text=   (arln == 0 ? "  رقم الدخول :  " : "  Entry number :") ; label131.Text=   (arln == 0 ? "  رقم التأشيرة :  " : "  visa number :") ; line6.Text=   (arln == 0 ? "  line6  " : "  line6") ; bubbleBarTab11.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; label109.Text=   (arln == 0 ? "  تــــاريخ إصـــــــدارها :  " : "  Release date:") ; label110.Text=   (arln == 0 ? "  رخصـــــــة الموظــــف :  " : "  Employee's license:") ; label111.Text=   (arln == 0 ? "  المصــــــــــــدر :  " : "  The source:") ; label112.Text=   (arln == 0 ? "  تاريخ إنتهائهــــا :  " : "  Expiry date:") ; line5.Text=   (arln == 0 ? "  line5  " : "  line5") ; label105.Text=   (arln == 0 ? "  تــــاريخ إصـــــــدارها :  " : "  Release date:") ; label106.Text=   (arln == 0 ? "  إستمـــارة الموظــــف :  " : "  Employee application:") ; label107.Text=   (arln == 0 ? "  المصــــــــــــدر :  " : "  The source:") ; label108.Text=   (arln == 0 ? "  تاريخ إنتهائهــــا :  " : "  Expiry date:") ; line4.Text=   (arln == 0 ? "  line4  " : "  line4") ; label101.Text=   (arln == 0 ? "  تــــاريخ إصـــــــدارها :  " : "  Release date:") ; label102.Text=   (arln == 0 ? "  تأمـــــــين الموظــــف :  " : "  Employee insurance:") ; label103.Text=   (arln == 0 ? "  المصــــــــــــدر :  " : "  The source:") ; label104.Text=   (arln == 0 ? "  تاريخ إنتهائهــــا :  " : "  Expiry date:") ; label96.Text=   (arln == 0 ? "  تــــاريخ إصـــــــدارها :  " : "  Release date:") ; label98.Text=   (arln == 0 ? "  جــــــــواز الموظــــف :  " : "  Employee Permit:") ; label99.Text=   (arln == 0 ? "  المصــــــــــــدر :  " : "  The source:") ; label100.Text=   (arln == 0 ? "  تاريخ إنتهائهــــا :  " : "  Expiry date:") ; line3.Text=   (arln == 0 ? "  line3  " : "  line3") ; label88.Text=   (arln == 0 ? "  تــــاريخ إصـــــــدارها :  " : "  Release date:") ; label97.Text=   (arln == 0 ? "  هــــــوية الموظــــف :  " : "  Employee ID:") ; label95.Text=   (arln == 0 ? "  المصــــــــــــدر :  " : "  The source:") ; label92.Text=   (arln == 0 ? "  تاريخ إنتهائهــــا :  " : "  Expiry date:") ; labelX20.Text=   (arln == 0 ? "  This space intentionally left blank.  " : "  This space intentionally left blank.") ; superTabItem_Doc.Text=   (arln == 0 ? "  الـوثـــائق  " : "  Documents") ; buttonX_OpenFiles.Text=   (arln == 0 ? "    إضافة الوثائق  " : "    Add documents") ; buttonX_BrowserScannerFiles.Text=   (arln == 0 ? "    عرض الوثائق  " : "    View documents") ; buttonItem_EmpOut.Text=   (arln == 0 ? "      المفصولين  " : "      the separated") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; buttonItem_Back.Text=   (arln == 0 ? "  إسترجاع  " : "  recovery") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? " string.Empty " : " string.Empty") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */Text = "كرت الموظفـــــين";this.Text=   (arln == 0 ? "  كرت الموظفـــــين  " : "  staff card") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = string.Empty;
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Emp data_this;
        private T_Family DataThis_Family;
        private T_Attend Data_this_Attend;
        private BindingList<T_Attend> Update_Attend;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
       // private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "EmpsRepShort";
                        frm.Repvalue = "EmpsRepShort";
                        //ADDADD
                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    FrmReportsViewer.IsSettingOnly = false;
                }
                catch
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.Name.Contains("ribbonBar_Tasks"))
            {
                ribbonBar_Tasks.Font = new Font("Tahoma", 8F);
                ribbonBar1.BackgroundStyle.BackColor = Color.Gainsboro;
                ribbonBar1.BackgroundStyle.BackColor2 = Color.Gainsboro;
            }
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;
                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));
            }
        }
        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        private Panel PanelSpecialContainer;
        private void superTabControl_Main1_RightToLeftChanged(object sender, EventArgs e)
        {
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
            superTabControl_Main1.RightToLeft = RightToLeft.No;
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
        }
        public Softgroup.NetResize.NetResize netResize1;
        private Timer timer1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private Timer timerInfoBallon;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        public DotNetBarManager dotNetBarManager1;
        private ImageList imageList1;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ContextMenuStrip contextMenuStrip2;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private SuperTabControl superTabControl_Employee;
        private SuperTabControlPanel superTabControlPanel18;
        private LabelX labelX19;
        private SuperTabItem superTabItem_Acc;
        private SuperTabControlPanel superTabControlPanel17;
        private LabelX labelX18;
        private SuperTabItem superTabItem_Contract;
        private SuperTabControlPanel superTabControlPanel19;
        private LabelX labelX20;
        private SuperTabItem superTabItem_Doc;
        private SuperTabControlPanel superTabControlPanel15;
        private LabelX labelX15;
        private SuperTabItem superTabItem_Gen;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx3;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Panel panel1;
        private PanelEx panelEx1;
        private GroupBox groupBox1;
        private TextBoxX textBox_SocialInsuranceNo;
        private Panel panel2;
        private TextBox textBox_ExperiencesA;
        private Label label127;
        private ComboBoxEx comboBox_BloodTyp;
        private ComboBoxEx comboBox_BirthPlace;
        private Label label133;
        private TextBox textBox_Email;
        private Label label125;
        private TextBox textBox_Tel;
        private Label label124;
        private ComboBoxEx comboBox_CityNo;
        private Label label9;
        private ButtonX button_AddNewCity;
        private ButtonX button_SrchCities;
        private TextBox textBox_AddressA;
        private Label label126;
        private ComboBoxEx comboBox_Sex;
        private ComboBoxEx comboBox_MaritalStatus;
        private ComboBoxEx comboBox_Religion;
        private MaskedTextBox dateTimeInput_BirthDate;
        private Label label119;
        private Label label118;
        private Label label117;
        private Label label115;
        private Label label114;
        private Label label113;
        private ButtonX button_AddNewReligon;
        private ButtonX button_SrchReligon;
        private TextBox textBox_QualificationA;
        private ButtonX button_PhotoShoot;
        private LabelX labelX1;
        private ButtonX checkBox_ClearPic;
        private ButtonX button_Pic;
        private ComboBoxEx comboBox_Nationalty;
        private ButtonX button_AddNewNation;
        private ButtonX button_SrchNation;
        private Label label5;
        private ComboBoxEx comboBox_Guarantor;
        private ButtonX button_AddNewSponser;
        private ButtonX button_SrchGuartor;
        private Label label4;
        private ComboBoxEx comboBox_Job;
        private ButtonX button_AddNewJob;
        private ButtonX button_SrchJob;
        private Label label3;
        private ComboBoxEx comboBox_Section;
        private ButtonX button_AddNewSection;
        private ButtonX button_SrchSection;
        private Label label2;
        private ComboBoxEx comboBox_Dept;
        private ButtonX button_AddNewDept;
        private ButtonX button_SrchDept;
        private Label label12;
        private TextBox textBox_Pass;
        private Label label52;
        private Label label40;
        private Label label36;
        private Label label38;
        private GroupBox groupBox2;
        protected Label label1;
        protected Label label6;
        protected Label label7;
        protected Label label8;
        private DoubleInput textBox_CompPaying;
        private DoubleInput textBox_SalSubtract;
        private PanelEx panelEx4;
        private Label label11;
        private ComboBoxEx comboBox_ContrTyp;
        private DoubleInput textBox_HousingAllowance;
        private DoubleInput textBox_TransferAllowance;
        private DoubleInput textBox_NaturalWorkAllowance;
        private DoubleInput textBox_OtherAllowance;
        private DoubleInput textBox_MainSal;
        private Label label130;
        private Panel panel4;
        private DoubleInput textBox_InsuranceMedicalCom;
        private DoubleInput textBox_SocialInsuranceComp;
        private Label label80;
        private Label label78;
        private Label label79;
        private Label label74;
        private Label label75;
        private Label label76;
        private Label label73;
        private Label label72;
        private Label label70;
        private DoubleInput textBox_SubsistenceAllowance;
        private Line line1;
        private ComboBoxEx comboBox_Allowances;
        private ComboBoxEx comboBox_AllowancesTime;
        private Panel panel3;
        private MaskedTextBox dateTimeInput_LastFilter;
        private MaskedTextBox dateTimeInput_DateAppointment;
        private Label label56;
        private Label label53;
        private ComboBoxEx comboBox_DirBoss;
        private ButtonX button_AddNewBoss;
        private ButtonX button_SrchBoss;
        private Label label10;
        private IntegerInput textBox_DayOfMonth;
        private CheckBox checkBox_AutoReturnContr;
        private GroupBox groupBox4;
        private MaskedTextBox dateTimeInput_StartContr;
        private Label label54;
        private MaskedTextBox dateTimeInput_EndContr;
        private Label label55;
        private Label label137;
        private Label label140;
        private DoubleInput textBox_WorkHours;
        private Label label60;
        private Label label59;
        private Label label57;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private DoubleInput textBox_SocialInsurance;
        private DoubleInput textBox_InsuranceMedical;
        private DoubleInput textBox_LateHours;
        private DoubleInput textBox_DisOneDay;
        private Label label86;
        private Label label84;
        private Label label82;
        private Label label83;
        private Label label85;
        private GroupBox groupBox7;
        private DoubleInput textBox_MandateDay;
        private DoubleInput textBox_AddHours;
        private DoubleInput textBox_AddDay;
        private Label label89;
        private Label label90;
        private Label label91;
        private PanelEx panelEx5;
        private GroupBox groupBox3;
        private ExpandablePanel expandablePanel_attends;
        private ExpandablePanel expandablePanel_Sat;
        private ItemPanel itemPanel1;
        private ExpandablePanel expandablePanel_Fri;
        private ItemPanel itemPanel7;
        private ExpandablePanel expandablePanel_Thurs;
        private ItemPanel itemPanel6;
        private ExpandablePanel expandablePanel_Wen;
        private ItemPanel itemPanel5;
        private ExpandablePanel expandablePanel_Tuse;
        private ItemPanel itemPanel4;
        private ExpandablePanel expandablePanel_Mon;
        private ItemPanel itemPanel3;
        private ExpandablePanel expandablePanel_Sun;
        private ItemPanel itemPanel2;
        private GroupBox groupBox8;
        private DoubleInput textBox_TicketsCount;
        private DoubleInput textBox_TicketsBalance;
        private DoubleInput textBox_TicketsPrice;
        private Label label68;
        private Label label65;
        private Label label67;
        private DoubleInput textBox_VacationBalance;
        private Label label64;
        private GroupBox groupBox10;
        private IntegerInput textBox_VacationCount;
        private Label label62;
        private Label label63;
        private PanelEx panelEx6;
        private ComboBoxEx comboBox_ID_From;
        private ButtonX button_SrchID;
        private MaskedTextBox dateTimeInput_ID_Date;
        private MaskedTextBox dateTimeInput_ID_DateEnd;
        private TextBox textBox_ID_No;
        private Label label88;
        private Label label97;
        private Label label95;
        private Label label92;
        private Line line3;
        private ComboBoxEx comboBox_Passport_From;
        private ButtonX button_SrchPassport;
        private MaskedTextBox dateTimeInput_Pass_Date;
        private MaskedTextBox dateTimeInput_Passport_DateEnd;
        private TextBox textBox_Passport_No;
        private Label label96;
        private Label label98;
        private Label label99;
        private Label label100;
        private ComboBoxEx comboBox_Insurance_From;
        private ButtonX button_SrchInsurance;
        private Line line4;
        private MaskedTextBox dateTimeInput_Insurance_Date;
        private MaskedTextBox dateTimeInput_Insurance_DateEnd;
        private TextBox textBox_Insurance_No;
        private Label label101;
        private Label label102;
        private Label label103;
        private Label label104;
        private ComboBoxEx comboBox_License_From;
        private ButtonX button_SrchLicense;
        private Line line6;
        protected BubbleBar bubbleBar5;
        protected BubbleBarTab bubbleBarTab11;
        public BubbleButton bubbleButton5;
        private MaskedTextBox dateTimeInput_License_Date;
        private MaskedTextBox dateTimeInput_License_DateEnd;
        private TextBox textBox_License_No;
        private Label label109;
        private Label label110;
        private Label label111;
        private Label label112;
        private ComboBoxEx comboBox_Form_From;
        private ButtonX button_SrchForms;
        private Line line5;
        private MaskedTextBox dateTimeInput_Form_Date;
        private MaskedTextBox dateTimeInput_Form_DateEnd;
        private TextBox textBox_Form_No;
        private Label label105;
        private Label label106;
        private Label label107;
        private Label label108;
        protected TextBox textBox_NameE;
        protected TextBox textBox_NameA;
        protected TextBox textBox_ID;
        private LinkLabel linkLabel_ChangeEmpNo;
        private SwitchButton switchButton_SalStatus;
        private ComboBoxEx comboBox_CalculateNo;
        private TextBoxX textBox_WorkNo;
        private ButtonX button_AddNewBirthPlaces;
        private ButtonX button_SrchBirthPlaces;
        private ButtonX button_SrchReligion;
        private ButtonX button_AddNewContract;
        //private CachedRepGeneral cachedRepGeneral1;
        private ListBox listBox_ImageFiles;
        private ListBox listBox_ImageFiles2;
        private SwitchButton switchButton_AccType;
        private TextBox txtBXBankName;
        private ButtonX button_SrchBXBankNo;
        private TextBox txtBXBankNo;
        private RadioButton radioButton_SatBreakDay;
        private RadioButton radioButton_SatPeriods2;
        private RadioButton radioButton_SatPeriods1;
        private GroupPanel groupPanel1;
        private MaskedTextBox textBox_SatTimeAllow1;
        private Label label18;
        private MaskedTextBox textBox_SatTime1;
        private Label label14;
        private MaskedTextBox textBox_SatLeaveTime1;
        private Label label19;
        private GroupPanel groupPanel2;
        private MaskedTextBox textBox_SatLeaveTime2;
        private Label label20;
        private MaskedTextBox textBox_SatTimeAllow2;
        private Label label21;
        private MaskedTextBox textBox_SatTime2;
        private Label label22;
        private GroupPanel groupPanel3;
        private MaskedTextBox textBox_SunLeaveTime2;
        private Label label23;
        private MaskedTextBox textBox_SunTimeAllow2;
        private Label label24;
        private MaskedTextBox textBox_SunTime2;
        private Label label25;
        private GroupPanel groupPanel4;
        private MaskedTextBox textBox_SunLeaveTime1;
        private Label label26;
        private MaskedTextBox textBox_SunTimeAllow1;
        private Label label27;
        private MaskedTextBox textBox_SunTime1;
        private Label label28;
        private RadioButton radioButton_SunBreakDay;
        private RadioButton radioButton_SunPeriods2;
        private RadioButton radioButton_SunPeriods1;
        private GroupPanel groupPanel5;
        private MaskedTextBox textBox_MonLeaveTime2;
        private Label label29;
        private MaskedTextBox textBox_MonTimeAllow2;
        private Label label30;
        private MaskedTextBox textBox_MonTime2;
        private Label label31;
        private GroupPanel groupPanel6;
        private MaskedTextBox textBox_MonLeaveTime1;
        private Label label32;
        private MaskedTextBox textBox_MonTimeAllow1;
        private Label label33;
        private MaskedTextBox textBox_MonTime1;
        private Label label34;
        private RadioButton radioButton_MonBreakDay;
        private RadioButton radioButton_MonPeriods2;
        private RadioButton radioButton_MonPeriods1;
        private GroupPanel groupPanel11;
        private MaskedTextBox textBox_LeaveTime2;
        private Label label50;
        private MaskedTextBox textBox_FriTimeAllow2;
        private Label label51;
        private MaskedTextBox textBox_FriTime2;
        private Label label58;
        private GroupPanel groupPanel12;
        private MaskedTextBox textBox_LeaveTime1;
        private Label label61;
        private MaskedTextBox textBox_FriTimeAllow1;
        private Label label66;
        private MaskedTextBox textBox_FriTime1;
        private Label label69;
        private RadioButton radioButton_FriBreakDay;
        private RadioButton radioButton_FriPeriods2;
        private RadioButton radioButton_FriPeriods1;
        private GroupPanel groupPanel13;
        private MaskedTextBox textBox_ThurLeaveTime2;
        private Label label71;
        private MaskedTextBox textBox_ThurTimeAllow2;
        private Label label77;
        private MaskedTextBox textBox_ThurTime2;
        private Label label81;
        private GroupPanel groupPanel14;
        private MaskedTextBox textBox_ThurLeaveTime1;
        private Label label87;
        private MaskedTextBox textBox_ThurTimeAllow1;
        private Label label93;
        private MaskedTextBox textBox_ThurTime1;
        private Label label94;
        private RadioButton radioButton_ThurBreakDay;
        private RadioButton radioButton_ThurPeriods2;
        private RadioButton radioButton_ThurPeriods1;
        private GroupPanel groupPanel9;
        private MaskedTextBox textBox_WenLeaveTime2;
        private Label label44;
        private MaskedTextBox textBox_WenTimeAllow2;
        private Label label45;
        private MaskedTextBox textBox_WenTime2;
        private Label label46;
        private GroupPanel groupPanel10;
        private MaskedTextBox textBox_WenLeaveTime1;
        private Label label47;
        private MaskedTextBox textBox_WenTimeAllow1;
        private Label label48;
        private MaskedTextBox textBox_WenTime1;
        private Label label49;
        private RadioButton radioButton_WenBreakDay;
        private RadioButton radioButton_WenPeriods2;
        private RadioButton radioButton_WenPeriods1;
        private GroupPanel groupPanel7;
        private MaskedTextBox textBox_TusLeaveTime2;
        private Label label35;
        private MaskedTextBox textBox_TusTimeAllow2;
        private Label label37;
        private MaskedTextBox textBox_TusTime2;
        private Label label39;
        private GroupPanel groupPanel8;
        private MaskedTextBox textBox_TusLeaveTime1;
        private Label label41;
        private MaskedTextBox textBox_TusTimeAllow1;
        private Label label42;
        private MaskedTextBox textBox_TusTime1;
        private Label label43;
        private RadioButton radioButton_TusBreakDay;
        private RadioButton radioButton_TusPeriods2;
        private RadioButton radioButton_TusPeriods1;
        private PictureBox pictureBox_EnterPic;
        protected ButtonItem buttonItem_Back;
        private GroupBox groupBox14;
        private MaskedTextBox dateTimeInput_VisaDate;
        private TextBox textBox_VisaCountry;
        private Label label136;
        private Label label135;
        private TextBox textBox_VisaEnterNo;
        private Label label134;
        private TextBox textBox_VisaNo;
        private Label label131;
        private Line line2;
        private SuperTabControlPanel superTabControlPanel1;
        private PanelEx panelEx8;
        private SuperTabItem superTabItem_Family;
        private MaskedTextBox dateTimeInput_PassportDateEnd15;
        private MaskedTextBox dateTimeInput_PassportDateEnd14;
        private MaskedTextBox dateTimeInput_PassportDateEnd13;
        private MaskedTextBox dateTimeInput_PassportDateEnd12;
        private MaskedTextBox dateTimeInput_PassportDateEnd11;
        private MaskedTextBox dateTimeInput_PassportDateEnd10;
        private MaskedTextBox dateTimeInput_PassportDateEnd9;
        private MaskedTextBox dateTimeInput_PassportDateEnd8;
        private MaskedTextBox dateTimeInput_PassportDateEnd7;
        private MaskedTextBox dateTimeInput_PassportDateEnd6;
        private MaskedTextBox dateTimeInput_PassportDateEnd5;
        private MaskedTextBox dateTimeInput_PassportDateEnd4;
        private MaskedTextBox dateTimeInput_PassportDateEnd3;
        private MaskedTextBox dateTimeInput_PassportDateEnd2;
        private MaskedTextBox dateTimeInput_PassportDateEnd1;
        private MaskedTextBox dateTimeInput_BirthDate15;
        private MaskedTextBox dateTimeInput_BirthDate14;
        private MaskedTextBox dateTimeInput_BirthDate13;
        private MaskedTextBox dateTimeInput_BirthDate12;
        private MaskedTextBox dateTimeInput_BirthDate11;
        private MaskedTextBox dateTimeInput_BirthDate10;
        private MaskedTextBox dateTimeInput_BirthDate9;
        private MaskedTextBox dateTimeInput_BirthDate8;
        private MaskedTextBox dateTimeInput_BirthDate7;
        private MaskedTextBox dateTimeInput_BirthDate6;
        private MaskedTextBox dateTimeInput_BirthDate5;
        private MaskedTextBox dateTimeInput_BirthDate4;
        private MaskedTextBox dateTimeInput_BirthDate3;
        private MaskedTextBox dateTimeInput_BirthDate2;
        private MaskedTextBox dateTimeInput_BirthDate1;
        private Label label122;
        private Label label123;
        private Label label128;
        private Label label129;
        private TextBox textBox_PassporntNo15;
        private TextBox textBox_Relation15;
        private TextBox textBox_Name15;
        private TextBox textBox_PassporntNo14;
        private TextBox textBox_Relation14;
        private TextBox textBox_Name14;
        private TextBox textBox_PassporntNo13;
        private TextBox textBox_Relation13;
        private TextBox textBox_Name13;
        private TextBox textBox_PassporntNo12;
        private TextBox textBox_Relation12;
        private TextBox textBox_Name12;
        private TextBox textBox_PassporntNo11;
        private TextBox textBox_Relation11;
        private TextBox textBox_Name11;
        private TextBox textBox_PassporntNo10;
        private TextBox textBox_Relation10;
        private TextBox textBox_Name10;
        private TextBox textBox_PassporntNo9;
        private TextBox textBox_Relation9;
        private TextBox textBox_Name9;
        private TextBox textBox_PassporntNo8;
        private TextBox textBox_Relation8;
        private TextBox textBox_Name8;
        private TextBox textBox_PassporntNo7;
        private TextBox textBox_Relation7;
        private TextBox textBox_Name7;
        private TextBox textBox_PassporntNo6;
        private TextBox textBox_Relation6;
        private TextBox textBox_Name6;
        private TextBox textBox_PassporntNo5;
        private TextBox textBox_Relation5;
        private TextBox textBox_Name5;
        private TextBox textBox_PassporntNo4;
        private TextBox textBox_Relation4;
        private TextBox textBox_Name4;
        private TextBox textBox_PassporntNo3;
        private TextBox textBox_Relation3;
        private TextBox textBox_Name3;
        private TextBox textBox_PassporntNo2;
        private TextBox textBox_Relation2;
        private TextBox textBox_Name2;
        private TextBox textBox_PassporntNo1;
        private TextBox textBox_Relation1;
        private TextBox textBox_Name1;
        private Label label132;
        private ButtonX button_SaveFamily;
        private GroupBox groupBox9;
        private TextBox textBox_Insurance_Class;
        private Label label121;
        private ComboBoxEx comboBox_InsuranceType;
        private ButtonX button_InsuranceType;
        private ButtonX bubbleButton_InsuranceType;
        private Label label120;
        private TextBoxX textBox_Note;
        private ButtonItem buttonX_OpenFiles;
        private ButtonItem buttonX_BrowserScannerFiles;
        private ButtonItem buttonItem_EmpOut;
        private GroupPanel groupPanel15;
        private ButtonX button_SrchCostCenterAcc;
        private TextBox textBox_CostCenter;
        private Label label116;
        internal TextBox textBox_CostCenterName;
        private ButtonX button_SrchAdvancAcc;
        private TextBox textBox_AccLoan;
        private Label label17;
        internal TextBox textBox_AccLoanName;
        private ButtonX button_SrchHousAcc;
        private TextBox textBox_AccHousing;
        private Label label16;
        internal TextBox textBox_AccHousingName;
        private ButtonX button_SrchSalAcc;
        private TextBox textBox_AccSal;
        private Label label15;
        internal TextBox textBox_AccSalName;
        private LabelItem lable_Records;
        private ButtonX button_BankCall;
        public FormState State
        {
            get
            {
                return statex;
            }
            set
            {
                statex = value;
            }
        }
        public bool IfAdd
        {
            set
            {
                Button_Add.Visible = value;
            }
        }
        public bool IfDelete
        {
            set
            {
                Button_Delete.Visible = value;
                superTabControl_Main1.Refresh();
            }
        }
        public bool IfSave
        {
            set
            {
                Button_Save.Visible = value;
            }
        }
        protected bool CanUpdate
        {
            get
            {
                return canUpdate;
            }
            set
            {
                canUpdate = value;
            }
        }
        public List<string> PKeys
        {
            get
            {
                return pkeys;
            }
            set
            {
                pkeys = value;
            }
        }
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_Save.Enabled = !value;
                buttonX_OpenFiles.Enabled = value;
                buttonX_BrowserScannerFiles.Enabled = value;
                linkLabel_ChangeEmpNo.Enabled = value;
                button_SaveFamily.Enabled = value;
            }
        }
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance;
            }
        }
        public T_Emp DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
                SetData(data_this);
            }
        }
        public T_Family DataThisFamily
        {
            get
            {
                return DataThis_Family;
            }
            set
            {
                DataThis_Family = value;
            }
        }
        public T_Attend Datathis_Attend
        {
            get
            {
                return Data_this_Attend;
            }
            set
            {
                Data_this_Attend = value;
            }
        }
        public BindingList<T_Attend> UpdateAttend
        {
            get
            {
                return Update_Attend;
            }
            set
            {
                Update_Attend = value;
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
        }
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value != null && value.UsrNo != string.Empty)
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 1) || buttonItem_EmpOut.Checked)
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 2) || buttonItem_EmpOut.Checked)
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 3) || buttonItem_EmpOut.Checked)
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
            }
        }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Prev_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                if (index > 1)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index - 1);
                }
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Next_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                int count = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                try
                {
                    count = Convert.ToInt32(Label_Count.Text);
                }
                catch
                {
                }
                if (index < count)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index + 1);
                }
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Last_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = Label_Count.Text;
                UpdateVcr();
            }
        }
        private void UpdateVcr()
        {
            int vCount = 0;
            int vPosition = 0;
            try
            {
                vCount = int.Parse(Label_Count.Text);
            }
            catch
            {
                vCount = 0;
            }
            try
            {
                vPosition = int.Parse(TextBox_Index.Text);
            }
            catch
            {
                vPosition = 0;
            }
            if (vCount <= 1)
            {
                Button_First.Enabled = false;
                Button_Prev.Enabled = false;
                Button_Next.Enabled = false;
                Button_Last.Enabled = false;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    lable_Records.Text = ((vCount == 0) ? "لايوجد سجلات" : "سجل واحد فقط");
                }
                else
                {
                    lable_Records.Text = ((vCount == 0) ? "No records" : "Only Record");
                }
                return;
            }
            if (vPosition == 1)
            {
                ButtonItem button_First = Button_First;
                bool enabled = (Button_Prev.Enabled = false);
                button_First.Enabled = enabled;
                ButtonItem button_Last = Button_Last;
                enabled = (Button_Next.Enabled = vCount > 1);
                button_Last.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    lable_Records.Text = "الأول من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Text = "First of " + vCount + " records";
                }
                return;
            }
            if (vPosition == vCount)
            {
                Button_Last.Enabled = false;
                Button_Next.Enabled = false;
                ButtonItem button_First2 = Button_First;
                bool enabled = (Button_Prev.Enabled = vCount > 1);
                button_First2.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    lable_Records.Text = "الأخير من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Text = "Last of " + vCount + " records";
                }
                return;
            }
            Button_First.Enabled = true;
            Button_Prev.Enabled = true;
            Button_Next.Enabled = true;
            Button_Last.Enabled = true;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                lable_Records.Text = "السجل " + vPosition + " من " + vCount;
            }
            else
            {
                lable_Records.Text = "Record " + vPosition + " of " + vCount;
            }
        }
        protected bool ContinueIfEditOrNew()
        {
            if (State == FormState.Edit || State == FormState.New)
            {
                if (MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        public void Button_Search_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Emp";
                VarGeneral.FrmEmpStat = VarGeneral.FrmEmpStat;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    T_Emp q = db.EmpsEmpNo(frm.SerachNo);
                    if (!string.IsNullOrEmpty(q.Emp_ID))
                    {
                        textBox_ID.Text = q.Emp_No;
                    }
                }
            }
            catch
            {
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = string.Empty;
        }
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
        }
        public void ViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? string.Empty) <= 0 || (Label_Count.Text ?? string.Empty) == string.Empty)
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                DGV_Main.PrimaryGrid.DataSource = null;
                DGV_Main.PrimaryGrid.VirtualMode = false;
                ViewState = ViewState.Deiles;
            }
            catch
            {
            }
        }
        public void ViewTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? string.Empty) <= 0 || (Label_Count.Text ?? string.Empty) == string.Empty)
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                ViewState = ViewState.Table;
            }
            catch
            {
            }
            Fill_DGV_Main();
            int index = -1;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
                index = -1;
            }
            index--;
            if (index < DGV_Main.PrimaryGrid.Rows.Count && index >= 0)
            {
                DGV_Main.PrimaryGrid.Rows[index].EnsureVisible();
            }
        }
        private void DGV_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridElement item = DGV_Main.GetElementAt(e.Location);
                if (item is GridColumnHeader)
                {
                    GridColumnHeader gch = (GridColumnHeader)item;
                    GridColumn column = null;
                    HeaderArea area = gch.GetHitArea(e.Location, ref column);
                    contextMenuStrip1.Show(Control.MousePosition);
                }
                else
                {
                    contextMenuStrip2.Show(Control.MousePosition);
                }
            }
        }
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            List<T_Emp> list = db.FillEmps_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Emp> new_data_enum)
        {
            bool contextMenuSet = false;
            if (contextMenuStrip1.Items.Count > 0)
            {
                contextMenuSet = true;
            }
            for (int i = 0; i < DGV_Main.PrimaryGrid.Columns.Count; i++)
            {
                if (columns_Names_visible.ContainsKey(DGV_Main.PrimaryGrid.Columns[i].Name))
                {
                    DGV_Main.PrimaryGrid.Columns[i].AutoSizeMode = ColumnAutoSizeMode.None;
                    DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 50;
                    DGV_Main.PrimaryGrid.Columns[i].Visible = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                    DGV_Main.PrimaryGrid.Columns[i].HeaderText = ((LangArEn == 0) ? columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].AText : columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].EText);
                    if (!contextMenuSet)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Checked = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                        item.CheckOnClick = true;
                        item.Name = DGV_Main.PrimaryGrid.Columns[i].Name;
                        item.Text = DGV_Main.PrimaryGrid.Columns[i].HeaderText;
                        item.CheckedChanged += item_Click;
                        contextMenuStrip1.Items.Add(item);
                    }
                    else
                    {
                        DGV_Main.PrimaryGrid.Columns[i].Visible = (contextMenuStrip1.Items[DGV_Main.PrimaryGrid.Columns[i].Name] as ToolStripMenuItem).Checked;
                    }
                }
                else
                {
                    DGV_Main.PrimaryGrid.Columns[i].Visible = false;
                }
            }
            DGV_Main.PrimaryGrid.DataSource = new_data_enum.ToList();
            DGV_Main.PrimaryGrid.DataMember = "T_Emp";
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color2 = Color.LightBlue;
        }
        private void item_Click(object sender, EventArgs e)
        {
            string name = (sender as ToolStripMenuItem).Name;
            try
            {
                string NameExsist = DGV_Main.PrimaryGrid.Columns[name].Name;
            }
            catch
            {
                DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(name));
                DGV_Main.PrimaryGrid.Columns[name].AutoSizeMode = ColumnAutoSizeMode.None;
                DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 90;
                DGV_Main.PrimaryGrid.Columns[name].HeaderText = columns_Names_visible[name].AText;
            }
            DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
        }
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Emp();
            Data_this_Attend = new T_Attend();
            Update_Attend = new BindingList<T_Attend>();
            State = FormState.New;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        (controls[i] as DateTimePicker).Value = Convert.ToDateTime(n.GDateNow());
                    }
                    else
                    {
                        (controls[i] as DateTimePicker).Text = n.HDateNow();
                    }
                }
                else if (controls[i].GetType() == typeof(CheckBox))
                {
                    (controls[i] as CheckBox).Checked = false;
                }
                else if (controls[i].GetType() == typeof(PictureBox))
                {
                    (controls[i] as PictureBox).Image = null;
                }
                else if (!(controls[i].Name == codeControl.Name))
                {
                    if (controls[i].GetType() == typeof(DoubleInput))
                    {
                        (controls[i] as DoubleInput).Value = 0.0;
                    }
                    else if (controls[i].GetType() == typeof(IntegerInput))
                    {
                        (controls[i] as IntegerInput).Value = 0;
                    }
                    else if (controls[i].GetType() == typeof(TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                    {
                        controls[i].Text = string.Empty;
                    }
                    else if (controls[i].GetType() == typeof(CheckBox))
                    {
                        (controls[i] as CheckBox).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(RadioButton))
                    {
                        (controls[i] as RadioButton).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(ComboBox))
                    {
                        (controls[i] as ComboBox).SelectedIndex = 0;
                    }
                    else if (controls[i].GetType() == typeof(SwitchButton))
                    {
                        (controls[i] as SwitchButton).Value = true;
                    }
                }
            }
            textBox_ID.Focus();
            if (State == FormState.New)
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_DateAppointment.Text = Convert.ToDateTime(VarGeneral.Gdate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateAppointment.Text = Convert.ToDateTime(VarGeneral.Hdate).ToString("yyyy/MM/dd");
                }
            }
            Guid id = Guid.NewGuid();
            textBox_ID.Tag = id.ToString();
            textBox_DayOfMonth.Value = 30;
            textBox_WorkHours.Value = 9.0;
            radioButton_SatPeriods1.Checked = false;
            radioButton_SatPeriods2.Checked = false;
            radioButton_SatBreakDay.Checked = false;
            radioButton_SunPeriods1.Checked = false;
            radioButton_SunPeriods2.Checked = false;
            radioButton_SunBreakDay.Checked = false;
            radioButton_MonPeriods1.Checked = false;
            radioButton_MonPeriods2.Checked = false;
            radioButton_MonBreakDay.Checked = false;
            radioButton_TusPeriods1.Checked = false;
            radioButton_TusPeriods2.Checked = false;
            radioButton_TusBreakDay.Checked = false;
            radioButton_WenPeriods1.Checked = false;
            radioButton_WenPeriods2.Checked = false;
            radioButton_WenBreakDay.Checked = false;
            radioButton_ThurPeriods1.Checked = false;
            radioButton_ThurPeriods2.Checked = false;
            radioButton_ThurBreakDay.Checked = false;
            radioButton_FriPeriods1.Checked = false;
            radioButton_FriPeriods2.Checked = false;
            radioButton_FriBreakDay.Checked = false;
            textBox_SatTime1.Text = string.Empty;
            textBox_SatTime2.Text = string.Empty;
            textBox_SatLeaveTime1.Text = string.Empty;
            textBox_SatLeaveTime2.Text = string.Empty;
            textBox_SatTimeAllow1.Text = string.Empty;
            textBox_SatTimeAllow2.Text = string.Empty;
            textBox_SunTime1.Text = string.Empty;
            textBox_SunTime2.Text = string.Empty;
            textBox_SunLeaveTime1.Text = string.Empty;
            textBox_SunLeaveTime2.Text = string.Empty;
            textBox_SunTimeAllow1.Text = string.Empty;
            textBox_SunTimeAllow2.Text = string.Empty;
            textBox_MonTime1.Text = string.Empty;
            textBox_MonTime2.Text = string.Empty;
            textBox_MonLeaveTime1.Text = string.Empty;
            textBox_MonLeaveTime2.Text = string.Empty;
            textBox_MonTimeAllow1.Text = string.Empty;
            textBox_MonTimeAllow2.Text = string.Empty;
            textBox_TusTime1.Text = string.Empty;
            textBox_TusTime2.Text = string.Empty;
            textBox_TusLeaveTime1.Text = string.Empty;
            textBox_TusLeaveTime2.Text = string.Empty;
            textBox_TusTimeAllow1.Text = string.Empty;
            textBox_TusTimeAllow2.Text = string.Empty;
            textBox_WenTime1.Text = string.Empty;
            textBox_WenTime2.Text = string.Empty;
            textBox_WenLeaveTime1.Text = string.Empty;
            textBox_WenLeaveTime2.Text = string.Empty;
            textBox_WenTimeAllow1.Text = string.Empty;
            textBox_WenTimeAllow2.Text = string.Empty;
            textBox_ThurTime1.Text = string.Empty;
            textBox_ThurTime2.Text = string.Empty;
            textBox_ThurLeaveTime1.Text = string.Empty;
            textBox_ThurLeaveTime2.Text = string.Empty;
            textBox_ThurTimeAllow1.Text = string.Empty;
            textBox_ThurTimeAllow2.Text = string.Empty;
            textBox_FriTime1.Text = string.Empty;
            textBox_FriTime2.Text = string.Empty;
            textBox_LeaveTime1.Text = string.Empty;
            textBox_LeaveTime2.Text = string.Empty;
            textBox_FriTimeAllow1.Text = string.Empty;
            textBox_FriTimeAllow2.Text = string.Empty;
            if (comboBox_CalculateNo.Items.Count > 1)
            {
                comboBox_CalculateNo.SelectedIndex = 1;
            }
            if (comboBox_Dept.Items.Count > 1)
            {
                comboBox_Dept.SelectedIndex = 1;
            }
            if (comboBox_Job.Items.Count > 1)
            {
                comboBox_Job.SelectedIndex = 1;
            }
            if (comboBox_Section.Items.Count > 1)
            {
                comboBox_Section.SelectedIndex = 1;
            }
            if (comboBox_Guarantor.Items.Count > 1)
            {
                comboBox_Guarantor.SelectedIndex = 1;
            }
            if (comboBox_ContrTyp.Items.Count > 1)
            {
                comboBox_ContrTyp.SelectedIndex = 1;
            }
            if (comboBox_Allowances.Items.Count > 0)
            {
                comboBox_Allowances.SelectedIndex = 0;
            }
            if (comboBox_AllowancesTime.Items.Count > 0)
            {
                comboBox_AllowancesTime.SelectedIndex = 0;
            }
            SetReadOnly = false;
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void textBox_NameA_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void expandableSplitter1_Click(object sender, EventArgs e)
        {
            if (expandableSplitter1.Expanded)
            {
                ViewTable_Click(sender, e);
            }
            else
            {
                ViewDetails_Click(sender, e);
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && Button_Add.Enabled && Button_Add.Visible)
            {
                Button_Add_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3 && Button_Delete.Enabled && Button_Delete.Visible && State == FormState.Saved)
            {
                Button_Delete_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4 && Button_Search.Enabled && Button_Search.Visible)
            {
                Button_Search_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5 && Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
            {
                Button_Print_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10 && Button_ExportTable2.Enabled && Button_ExportTable2.Visible && !expandableSplitter1.Expanded)
            {
                Button_ExportTable2_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6 && buttonItem_Back.Enabled && buttonItem_Back.Visible && buttonItem_EmpOut.Checked)
            {
                buttonItem_Back_Click(sender, e);
            }
            else
            {
                if (e.KeyCode != Keys.Escape)
                {
                    return;
                }
                if (State == FormState.Saved)
                {
                    Close();
                    return;
                }
                if (State != FormState.New)
                {
                    textBox_ID_TextChanged(sender, e);
                    return;
                }
                try
                {
                    if (int.Parse(Label_Count.Text) > 0)
                    {
                        Button_Last_Click(sender, e);
                    }
                    else
                    {
                        Close();
                    }
                }
                catch
                {
                    Close();
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select Emp_No from T_Emp where EmpState =" + (VarGeneral.FrmEmpStat ? 1 : 0) + " order by Emp_No", new object[0]).ToList();
            }
            catch
            {
                PKeys.Clear();
            }
            int count = 0;
            count = PKeys.Count;
            try
            {
                PKeys = PKeys.OrderBy((string c) => int.Parse(c)).ToList();
            }
            catch
            {
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_SalSubtract);
                controls.Add(textBox_CompPaying);
                controls.Add(checkBox_ClearPic);
                controls.Add(comboBox_Allowances);
                controls.Add(comboBox_AllowancesTime);
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(listBox_ImageFiles);
                controls.Add(textBox_NameA);
                controls.Add(textBox_AccSal);
                controls.Add(textBox_AccLoan);
                controls.Add(textBox_VisaNo);
                controls.Add(textBox_VisaEnterNo);
                controls.Add(dateTimeInput_VisaDate);
                controls.Add(textBox_VisaCountry);
                controls.Add(textBox_CostCenter);
                controls.Add(textBox_CostCenterName);
                controls.Add(textBox_AccHousing);
                controls.Add(textBox_AccSalName);
                controls.Add(textBox_AccHousingName);
                controls.Add(textBox_AccLoanName);
                controls.Add(txtBXBankNo);
                controls.Add(txtBXBankName);
                controls.Add(switchButton_AccType);
                controls.Add(switchButton_SalStatus);
                controls.Add(textBox_NameE);
                controls.Add(textBox_Note);
                controls.Add(textBox_ID_No);
                controls.Add(textBox_AddDay);
                controls.Add(textBox_AddHours);
                controls.Add(textBox_AddressA);
                controls.Add(textBox_DayOfMonth);
                controls.Add(textBox_DisOneDay);
                controls.Add(textBox_Email);
                controls.Add(textBox_ID);
                controls.Add(textBox_ExperiencesA);
                controls.Add(textBox_Form_No);
                controls.Add(textBox_HousingAllowance);
                controls.Add(textBox_ID);
                controls.Add(textBox_Insurance_No);
                controls.Add(textBox_Insurance_Class);
                controls.Add(textBox_InsuranceMedical);
                controls.Add(textBox_LateHours);
                controls.Add(textBox_License_No);
                controls.Add(textBox_MainSal);
                controls.Add(textBox_MandateDay);
                controls.Add(textBox_NaturalWorkAllowance);
                controls.Add(textBox_Note);
                controls.Add(textBox_OtherAllowance);
                controls.Add(textBox_Pass);
                controls.Add(textBox_Passport_No);
                controls.Add(textBox_QualificationA);
                controls.Add(textBox_SocialInsurance);
                controls.Add(textBox_SocialInsuranceComp);
                controls.Add(textBox_InsuranceMedicalCom);
                controls.Add(textBox_SocialInsuranceNo);
                controls.Add(textBox_WorkNo);
                controls.Add(textBox_SubsistenceAllowance);
                controls.Add(textBox_Tel);
                controls.Add(textBox_TicketsBalance);
                controls.Add(textBox_TicketsCount);
                controls.Add(textBox_TicketsPrice);
                controls.Add(textBox_TransferAllowance);
                controls.Add(textBox_VacationBalance);
                controls.Add(textBox_VacationCount);
                controls.Add(textBox_WorkHours);
                controls.Add(checkBox_AutoReturnContr);
                controls.Add(dateTimeInput_BirthDate);
                controls.Add(dateTimeInput_DateAppointment);
                controls.Add(dateTimeInput_EndContr);
                controls.Add(dateTimeInput_Form_Date);
                controls.Add(dateTimeInput_Form_DateEnd);
                controls.Add(dateTimeInput_ID_Date);
                controls.Add(dateTimeInput_ID_DateEnd);
                controls.Add(dateTimeInput_Insurance_Date);
                controls.Add(dateTimeInput_Insurance_DateEnd);
                controls.Add(dateTimeInput_LastFilter);
                controls.Add(dateTimeInput_License_Date);
                controls.Add(dateTimeInput_License_DateEnd);
                controls.Add(dateTimeInput_Pass_Date);
                controls.Add(dateTimeInput_Passport_DateEnd);
                controls.Add(dateTimeInput_StartContr);
                controls.Add(comboBox_BirthPlace);
                controls.Add(comboBox_BloodTyp);
                controls.Add(comboBox_CalculateNo);
                controls.Add(comboBox_CityNo);
                controls.Add(comboBox_ContrTyp);
                controls.Add(comboBox_Dept);
                controls.Add(comboBox_DirBoss);
                controls.Add(comboBox_Form_From);
                controls.Add(comboBox_Guarantor);
                controls.Add(comboBox_ID_From);
                controls.Add(comboBox_Insurance_From);
                controls.Add(comboBox_Job);
                controls.Add(comboBox_License_From);
                controls.Add(comboBox_MaritalStatus);
                controls.Add(comboBox_Nationalty);
                controls.Add(comboBox_Passport_From);
                controls.Add(comboBox_Religion);
                controls.Add(comboBox_Section);
                controls.Add(comboBox_Sex);
                controls.Add(pictureBox_EnterPic);
                controls.Add(comboBox_InsuranceType);
                controls.Add(dateTimeInput_BirthDate1);
                controls.Add(dateTimeInput_BirthDate2);
                controls.Add(dateTimeInput_BirthDate3);
                controls.Add(dateTimeInput_BirthDate4);
                controls.Add(dateTimeInput_BirthDate5);
                controls.Add(dateTimeInput_BirthDate6);
                controls.Add(dateTimeInput_BirthDate7);
                controls.Add(dateTimeInput_BirthDate8);
                controls.Add(dateTimeInput_BirthDate9);
                controls.Add(dateTimeInput_BirthDate10);
                controls.Add(dateTimeInput_BirthDate11);
                controls.Add(dateTimeInput_BirthDate12);
                controls.Add(dateTimeInput_BirthDate13);
                controls.Add(dateTimeInput_BirthDate14);
                controls.Add(dateTimeInput_BirthDate15);
                controls.Add(dateTimeInput_PassportDateEnd1);
                controls.Add(dateTimeInput_PassportDateEnd2);
                controls.Add(dateTimeInput_PassportDateEnd3);
                controls.Add(dateTimeInput_PassportDateEnd4);
                controls.Add(dateTimeInput_PassportDateEnd5);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd6);
                controls.Add(dateTimeInput_PassportDateEnd9);
                controls.Add(dateTimeInput_PassportDateEnd10);
                controls.Add(dateTimeInput_PassportDateEnd11);
                controls.Add(dateTimeInput_PassportDateEnd12);
                controls.Add(dateTimeInput_PassportDateEnd13);
                controls.Add(dateTimeInput_PassportDateEnd14);
                controls.Add(dateTimeInput_PassportDateEnd15);
                controls.Add(textBox_Name1);
                controls.Add(textBox_Name2);
                controls.Add(textBox_Name3);
                controls.Add(textBox_Name4);
                controls.Add(textBox_Name5);
                controls.Add(textBox_Name6);
                controls.Add(textBox_Name7);
                controls.Add(textBox_Name8);
                controls.Add(textBox_Name9);
                controls.Add(textBox_Name10);
                controls.Add(textBox_Name11);
                controls.Add(textBox_Name12);
                controls.Add(textBox_Name13);
                controls.Add(textBox_Name14);
                controls.Add(textBox_Name15);
                controls.Add(textBox_PassporntNo1);
                controls.Add(textBox_PassporntNo2);
                controls.Add(textBox_PassporntNo3);
                controls.Add(textBox_PassporntNo4);
                controls.Add(textBox_PassporntNo5);
                controls.Add(textBox_PassporntNo6);
                controls.Add(textBox_PassporntNo7);
                controls.Add(textBox_PassporntNo8);
                controls.Add(textBox_PassporntNo9);
                controls.Add(textBox_PassporntNo10);
                controls.Add(textBox_PassporntNo11);
                controls.Add(textBox_PassporntNo12);
                controls.Add(textBox_PassporntNo13);
                controls.Add(textBox_PassporntNo14);
                controls.Add(textBox_PassporntNo15);
                controls.Add(textBox_Relation1);
                controls.Add(textBox_Relation2);
                controls.Add(textBox_Relation3);
                controls.Add(textBox_Relation4);
                controls.Add(textBox_Relation5);
                controls.Add(textBox_Relation6);
                controls.Add(textBox_Relation7);
                controls.Add(textBox_Relation8);
                controls.Add(textBox_Relation9);
                controls.Add(textBox_Relation10);
                controls.Add(textBox_Relation11);
                controls.Add(textBox_Relation12);
                controls.Add(textBox_Relation13);
                controls.Add(textBox_Relation14);
                controls.Add(textBox_Relation15);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmEmpOn_ADD_Controls:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public FrmEmp()
        {
            InitializeComponent();this.Load += langloads;
            radioButton_FriBreakDay.Click += Button_Edit_Click;
            radioButton_FriPeriods1.Click += Button_Edit_Click;
            radioButton_FriPeriods2.Click += Button_Edit_Click;
            radioButton_MonBreakDay.Click += Button_Edit_Click;
            radioButton_MonPeriods1.Click += Button_Edit_Click;
            radioButton_MonPeriods2.Click += Button_Edit_Click;
            radioButton_SatBreakDay.Click += Button_Edit_Click;
            radioButton_SatPeriods1.Click += Button_Edit_Click;
            radioButton_SatPeriods2.Click += Button_Edit_Click;
            radioButton_SunBreakDay.Click += Button_Edit_Click;
            radioButton_SunPeriods1.Click += Button_Edit_Click;
            radioButton_SunPeriods2.Click += Button_Edit_Click;
            radioButton_ThurBreakDay.Click += Button_Edit_Click;
            radioButton_ThurPeriods1.Click += Button_Edit_Click;
            radioButton_ThurPeriods2.Click += Button_Edit_Click;
            radioButton_TusBreakDay.Click += Button_Edit_Click;
            radioButton_TusPeriods1.Click += Button_Edit_Click;
            radioButton_TusPeriods2.Click += Button_Edit_Click;
            radioButton_WenBreakDay.Click += Button_Edit_Click;
            radioButton_WenPeriods1.Click += Button_Edit_Click;
            radioButton_WenPeriods2.Click += Button_Edit_Click;
            textBox_ID_No.Click += Button_Edit_Click;
            textBox_ID.Click += Button_Edit_Click;
            textBox_NameA.Click += Button_Edit_Click;
            textBox_NameE.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            textBox_AddDay.Click += Button_Edit_Click;
            textBox_AddHours.Click += Button_Edit_Click;
            textBox_AddressA.Click += Button_Edit_Click;
            textBox_DayOfMonth.Click += Button_Edit_Click;
            textBox_DisOneDay.Click += Button_Edit_Click;
            textBox_Email.Click += Button_Edit_Click;
            textBox_ExperiencesA.Click += Button_Edit_Click;
            textBox_Form_No.Click += Button_Edit_Click;
            textBox_FriTime1.Click += Button_Edit_Click;
            textBox_FriTime2.Click += Button_Edit_Click;
            textBox_FriTimeAllow1.Click += Button_Edit_Click;
            textBox_FriTimeAllow2.Click += Button_Edit_Click;
            textBox_HousingAllowance.Click += Button_Edit_Click;
            textBox_Insurance_No.Click += Button_Edit_Click;
            textBox_InsuranceMedical.Click += Button_Edit_Click;
            textBox_LateHours.Click += Button_Edit_Click;
            textBox_LeaveTime1.Click += Button_Edit_Click;
            textBox_LeaveTime2.Click += Button_Edit_Click;
            textBox_License_No.Click += Button_Edit_Click;
            textBox_MainSal.Click += Button_Edit_Click;
            textBox_MandateDay.Click += Button_Edit_Click;
            textBox_MonLeaveTime1.Click += Button_Edit_Click;
            textBox_MonLeaveTime2.Click += Button_Edit_Click;
            textBox_MonTime1.Click += Button_Edit_Click;
            textBox_MonTime2.Click += Button_Edit_Click;
            textBox_MonTimeAllow1.Click += Button_Edit_Click;
            textBox_MonTimeAllow2.Click += Button_Edit_Click;
            textBox_NaturalWorkAllowance.Click += Button_Edit_Click;
            textBox_OtherAllowance.Click += Button_Edit_Click;
            textBox_Pass.Click += Button_Edit_Click;
            textBox_Passport_No.Click += Button_Edit_Click;
            textBox_QualificationA.Click += Button_Edit_Click;
            textBox_SatLeaveTime1.Click += Button_Edit_Click;
            textBox_SatLeaveTime2.Click += Button_Edit_Click;
            textBox_SatTime1.Click += Button_Edit_Click;
            textBox_SatTime2.Click += Button_Edit_Click;
            textBox_LeaveTime1.Click += Button_Edit_Click;
            textBox_LeaveTime2.Click += Button_Edit_Click;
            textBox_SatTimeAllow1.Click += Button_Edit_Click;
            textBox_SatTimeAllow2.Click += Button_Edit_Click;
            textBox_SocialInsurance.Click += Button_Edit_Click;
            textBox_SocialInsuranceComp.Click += Button_Edit_Click;
            textBox_InsuranceMedicalCom.Click += Button_Edit_Click;
            textBox_SocialInsuranceNo.Click += Button_Edit_Click;
            textBox_WorkNo.Click += Button_Edit_Click;
            textBox_SubsistenceAllowance.Click += Button_Edit_Click;
            textBox_SunLeaveTime1.Click += Button_Edit_Click;
            textBox_SunLeaveTime2.Click += Button_Edit_Click;
            textBox_SunTime1.Click += Button_Edit_Click;
            textBox_SunTime2.Click += Button_Edit_Click;
            textBox_SunTimeAllow1.Click += Button_Edit_Click;
            textBox_SunTimeAllow2.Click += Button_Edit_Click;
            textBox_Tel.Click += Button_Edit_Click;
            textBox_ThurLeaveTime1.Click += Button_Edit_Click;
            textBox_ThurLeaveTime2.Click += Button_Edit_Click;
            textBox_ThurTime1.Click += Button_Edit_Click;
            textBox_ThurTime2.Click += Button_Edit_Click;
            textBox_ThurTimeAllow1.Click += Button_Edit_Click;
            textBox_ThurTimeAllow2.Click += Button_Edit_Click;
            textBox_TicketsBalance.Click += Button_Edit_Click;
            textBox_TicketsCount.Click += Button_Edit_Click;
            textBox_TicketsPrice.Click += Button_Edit_Click;
            textBox_TransferAllowance.Click += Button_Edit_Click;
            textBox_TusLeaveTime1.Click += Button_Edit_Click;
            textBox_TusLeaveTime2.Click += Button_Edit_Click;
            textBox_TusTimeAllow1.Click += Button_Edit_Click;
            textBox_TusTimeAllow2.Click += Button_Edit_Click;
            textBox_TusTime1.Click += Button_Edit_Click;
            textBox_TusTime2.Click += Button_Edit_Click;
            textBox_VacationBalance.Click += Button_Edit_Click;
            textBox_VacationCount.Click += Button_Edit_Click;
            textBox_WenLeaveTime1.Click += Button_Edit_Click;
            textBox_WenLeaveTime2.Click += Button_Edit_Click;
            textBox_WenTime1.Click += Button_Edit_Click;
            textBox_WenTime2.Click += Button_Edit_Click;
            textBox_WenTimeAllow1.Click += Button_Edit_Click;
            textBox_WenTimeAllow2.Click += Button_Edit_Click;
            textBox_WorkHours.Click += Button_Edit_Click;
            checkBox_AutoReturnContr.Click += Button_Edit_Click;
            comboBox_InsuranceType.Click += Button_Edit_Click;
            textBox_Insurance_Class.Click += Button_Edit_Click;
            dateTimeInput_DateAppointment.MouseDown += Button_Edit_Click;
            dateTimeInput_EndContr.MouseDown += Button_Edit_Click;
            dateTimeInput_Form_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_Form_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_ID_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_ID_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_Insurance_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_Insurance_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_LastFilter.MouseDown += Button_Edit_Click;
            dateTimeInput_License_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_License_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_Pass_Date.MouseDown += Button_Edit_Click;
            dateTimeInput_Passport_DateEnd.MouseDown += Button_Edit_Click;
            dateTimeInput_StartContr.MouseDown += Button_Edit_Click;
            comboBox_BirthPlace.Click += Button_Edit_Click;
            comboBox_BloodTyp.Click += Button_Edit_Click;
            comboBox_CalculateNo.Click += Button_Edit_Click;
            comboBox_CityNo.Click += Button_Edit_Click;
            comboBox_ContrTyp.Click += Button_Edit_Click;
            comboBox_Dept.Click += Button_Edit_Click;
            comboBox_DirBoss.Click += Button_Edit_Click;
            comboBox_Form_From.Click += Button_Edit_Click;
            comboBox_ID_From.Click += Button_Edit_Click;
            comboBox_Insurance_From.Click += Button_Edit_Click;
            comboBox_Job.Click += Button_Edit_Click;
            comboBox_License_From.Click += Button_Edit_Click;
            comboBox_MaritalStatus.Click += Button_Edit_Click;
            comboBox_Nationalty.Click += Button_Edit_Click;
            comboBox_Passport_From.Click += Button_Edit_Click;
            comboBox_Religion.Click += Button_Edit_Click;
            comboBox_Section.Click += Button_Edit_Click;
            comboBox_Sex.Click += Button_Edit_Click;
            switchButton_SalStatus.Click += Button_Edit_Click;
            switchButton_AccType.Click += Button_Edit_Click;
            button_Pic.Click += Button_Edit_Click;
            button_PhotoShoot.Click += Button_Edit_Click;
            checkBox_ClearPic.Click += Button_Edit_Click;
            textBox_AccHousing.Click += Button_Edit_Click;
            textBox_AccLoan.Click += Button_Edit_Click;
            textBox_AccSal.Click += Button_Edit_Click;
            textBox_CostCenter.Click += Button_Edit_Click;
            textBox_VisaNo.Click += Button_Edit_Click;
            textBox_VisaEnterNo.Click += Button_Edit_Click;
            dateTimeInput_VisaDate.Click += Button_Edit_Click;
            textBox_VisaCountry.Click += Button_Edit_Click;
            comboBox_Allowances.Click += Button_Edit_Click;
            comboBox_AllowancesTime.Click += Button_Edit_Click;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            textBox_ID.Click += textBox_ID_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            Button_PrintTable.Click += Button_Print_Click;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Button_First.Text = "الأول";
                Button_Last.Text = "الأخير";
                Button_Next.Text = "التالي";
                Button_Prev.Text = "السابق";
                Button_Add.Text = "جديد";
                Button_Close.Text = "اغلاق";
                Button_Delete.Text = "حذف";
                Button_Save.Text = "حفظ";
                Button_Search.Text = "بحث";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                buttonX_BrowserScannerFiles.Text = "  عرض الوثائق";
                buttonX_BrowserScannerFiles.Tooltip = "عرض وثائق وصور الموظف";
                buttonX_OpenFiles.Text = "  إضافة الوثائق";
                buttonX_OpenFiles.Tooltip = "إضافة وثائق وصور الموظف";
                superTabItem_Gen.Text = "عــــــــــام";
                superTabItem_Contract.Text = "العقــــــــد";
                superTabItem_Acc.Text = "الحسـابات";
                superTabItem_Doc.Text = "الـوثـــائق";
                superTabItem_Family.Text = "المرافقــين";
                textBox_SocialInsuranceNo.WatermarkText = "رقم التأمين الإجتماعي";
                textBox_SocialInsuranceNo.ButtonCustom.Text = "التأمين الإجتماعي  ";
                textBox_WorkNo.ButtonCustom.Text = "مكتب العمل";
                textBox_WorkNo.WatermarkText = "رقم مكتب العمل والعمال";
                button_BankCall.Tooltip = "حساب البنك";
                Text = "كرت الموظفــــــين";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Delete.Text = "Delete";
                Button_Save.Text = "Save";
                Button_Search.Text = "Search";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                buttonX_BrowserScannerFiles.Text = "     Show Doc";
                buttonX_BrowserScannerFiles.Tooltip = "Show Documents and images the Employee";
                buttonX_OpenFiles.Text = "     ADD Doc";
                buttonX_OpenFiles.Tooltip = "Add Documents and images to Employee";
                superTabItem_Gen.Text = "General";
                superTabItem_Contract.Text = "Contract";
                superTabItem_Acc.Text = "Acc";
                superTabItem_Doc.Text = "Doc";
                superTabItem_Family.Text = "Facilities";
                textBox_SocialInsuranceNo.WatermarkText = "Social Security No";
                textBox_SocialInsuranceNo.ButtonCustom.Text = "Social Security  ";
                textBox_WorkNo.ButtonCustom.Text = "Labor Office";
                textBox_WorkNo.WatermarkText = "Work and office workers";
                button_BankCall.Tooltip = "Bank Account";
                Text = "Staff Card";
            }
            expandablePanel_attends.TitleText = ((LangArEn == 0) ? "أوقات الدوام" : "Working hours");
        }
        private void FrmEmp_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEmp));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                    RightToLeft = RightToLeft.Yes;
                    LangArEn = 0;
                }
                else
                {
                    SSSLanguage.Language.ChangeLanguage("en", this, resources);
                    RightToLeft = RightToLeft.Yes;
                    LangArEn = 1;
                }
                RibunButtons();
                ADD_Controls();
                buttonItem_EmpOut_CheckedChanged(sender, e);
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void vMain()
        {
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            if (columns_Names_visible.Count == 0)
            {
                columns_Names_visible.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: true, string.Empty));
                columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible.Add("DateAppointment", new ColumnDictinary("تاريخ التعيين", "Appointment Date", ifDefault: true, string.Empty));
                columns_Names_visible.Add("StartContr", new ColumnDictinary("بداية العقد", "Start Contract Date", ifDefault: false, string.Empty));
                columns_Names_visible.Add("EndContr", new ColumnDictinary("نهاية العقد", "End Contract Date", ifDefault: false, string.Empty));
                columns_Names_visible.Add("MainSal", new ColumnDictinary("الراتب الأساسي", "Main Salary", ifDefault: true, string.Empty));
                columns_Names_visible.Add("ID_No", new ColumnDictinary("رقم الهوية", "ID No", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Passport_No", new ColumnDictinary("رقم الجواز", "Passport No", ifDefault: false, string.Empty));
                columns_Names_visible.Add("AddressA", new ColumnDictinary("العنوان", "Address", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Tel", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                columns_Names_visible.Add("Note", new ColumnDictinary(" الملاحظــات", "Note", ifDefault: true, string.Empty));
            }
            else
            {
                Clear();
                textBox_ID.Text = string.Empty;
                TextBox_Index.TextBox.Text = string.Empty;
            }
            FillCombo();
            RefreshPKeys();
            textBox_ID.Text = PKeys.FirstOrDefault();
            ViewDetails_Click(null, null);
            comboBox_InsuranceType_SelectedIndexChanged(null, null);
        }
        public void FillCombo()
        {
            comboBox_Allowances.Items.Clear();
            comboBox_Allowances.Items.Add("1");
            comboBox_Allowances.Items.Add("2");
            comboBox_Allowances.Items.Add("3");
            comboBox_Allowances.Items.Add("4");
            comboBox_Allowances.Items.Add("6");
            comboBox_Allowances.Items.Add("12");
            comboBox_Allowances.SelectedIndex = 0;
            comboBox_AllowancesTime.Items.Clear();
            comboBox_AllowancesTime.Items.Add((LangArEn == 0) ? "في أول المدة" : "Begining Preriod");
            comboBox_AllowancesTime.Items.Add((LangArEn == 0) ? "في آخر المدة" : "End Preriod");
            comboBox_AllowancesTime.SelectedIndex = 0;
            List<T_Job> listJob = new List<T_Job>(db.T_Jobs.Select((T_Job item) => item).ToList());
            listJob.Insert(0, new T_Job());
            comboBox_Job.DataSource = null;
            comboBox_Job.DataSource = listJob;
            comboBox_Job.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Job.ValueMember = "Job_No";
            List<T_Dept> listDept = new List<T_Dept>(db.T_Depts.Select((T_Dept item) => item).ToList());
            listDept.Insert(0, new T_Dept());
            comboBox_Dept.DataSource = null;
            comboBox_Dept.DataSource = listDept;
            comboBox_Dept.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Dept.ValueMember = "Dept_No";
            List<T_Section> listSection = new List<T_Section>(db.T_Sections.Select((T_Section item) => item).ToList());
            listSection.Insert(0, new T_Section());
            comboBox_Section.DataSource = null;
            comboBox_Section.DataSource = listSection;
            comboBox_Section.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Section.ValueMember = "Section_No";
            List<T_Guarantor> listGuarantor = new List<T_Guarantor>(db.T_Guarantors.Select((T_Guarantor item) => item).ToList());
            listGuarantor.Insert(0, new T_Guarantor());
            comboBox_Guarantor.DataSource = null;
            comboBox_Guarantor.DataSource = listGuarantor;
            comboBox_Guarantor.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Guarantor.ValueMember = "Guarantor_No";
            List<T_Sex> listSex = new List<T_Sex>(db.T_Sexes.Select((T_Sex item) => item).ToList());
            listSex.Insert(0, new T_Sex());
            comboBox_Sex.DataSource = null;
            comboBox_Sex.DataSource = listSex;
            comboBox_Sex.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Sex.ValueMember = "SexNo";
            List<T_Religion> listReligion = new List<T_Religion>(db.T_Religions.Select((T_Religion item) => item).ToList());
            listReligion.Insert(0, new T_Religion());
            comboBox_Religion.DataSource = null;
            comboBox_Religion.DataSource = listReligion;
            comboBox_Religion.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Religion.ValueMember = "Religion_No";
            List<T_MStatus> listMStatus = new List<T_MStatus>(db.T_MStatus.Select((T_MStatus item) => item).ToList());
            listMStatus.Insert(0, new T_MStatus());
            comboBox_MaritalStatus.DataSource = null;
            comboBox_MaritalStatus.DataSource = listMStatus;
            comboBox_MaritalStatus.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_MaritalStatus.ValueMember = "MStatusNo";
            comboBox_Nationalty.SelectedValueChanged -= comboBox_Nationalty_SelectedValueChanged;
            List<T_Nationality> listNation = new List<T_Nationality>(db.T_Nationalities.Select((T_Nationality item) => item).ToList());
            listNation.Insert(0, new T_Nationality());
            comboBox_Nationalty.DataSource = null;
            comboBox_Nationalty.DataSource = listNation;
            comboBox_Nationalty.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Nationalty.ValueMember = "Nation_No";
            comboBox_Nationalty.SelectedValueChanged += comboBox_Nationalty_SelectedValueChanged;
            List<T_City> listCity = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listCity.Insert(0, new T_City());
            comboBox_CityNo.DataSource = null;
            comboBox_CityNo.DataSource = listCity;
            comboBox_CityNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_CityNo.ValueMember = "City_No";
            List<T_BirthPlace> listBirthPlace = new List<T_BirthPlace>(db.T_BirthPlaces.Select((T_BirthPlace item) => item).ToList());
            listBirthPlace.Insert(0, new T_BirthPlace());
            comboBox_BirthPlace.DataSource = null;
            comboBox_BirthPlace.DataSource = listBirthPlace;
            comboBox_BirthPlace.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_BirthPlace.ValueMember = "BirthPlaceNo";
            List<T_City> listFormFrom = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listFormFrom.Insert(0, new T_City());
            comboBox_Form_From.DataSource = null;
            comboBox_Form_From.DataSource = listFormFrom;
            comboBox_Form_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Form_From.ValueMember = "City_No";
            List<T_City> listIDFrom = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listIDFrom.Insert(0, new T_City());
            comboBox_ID_From.DataSource = null;
            comboBox_ID_From.DataSource = listIDFrom;
            comboBox_ID_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_ID_From.ValueMember = "City_No";
            List<T_City> listInsurance = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listInsurance.Insert(0, new T_City());
            comboBox_Insurance_From.DataSource = null;
            comboBox_Insurance_From.DataSource = listInsurance;
            comboBox_Insurance_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Insurance_From.ValueMember = "City_No";
            List<T_City> listLicenseFrom = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listLicenseFrom.Insert(0, new T_City());
            comboBox_License_From.DataSource = null;
            comboBox_License_From.DataSource = listLicenseFrom;
            comboBox_License_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_License_From.ValueMember = "City_No";
            List<T_City> listPassport = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            listPassport.Insert(0, new T_City());
            comboBox_Passport_From.DataSource = null;
            comboBox_Passport_From.DataSource = listPassport;
            comboBox_Passport_From.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Passport_From.ValueMember = "City_No";
            List<T_BloodTyp> listBlood = new List<T_BloodTyp>(db.T_BloodTyps.Select((T_BloodTyp item) => item).ToList());
            listBlood.Insert(0, new T_BloodTyp());
            comboBox_BloodTyp.DataSource = null;
            comboBox_BloodTyp.DataSource = listBlood;
            comboBox_BloodTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_BloodTyp.ValueMember = "BloodTyp_No";
            comboBox_CalculateNo.SelectedValueChanged -= comboBox_CalculateNo_SelectedValueChanged;
            List<T_OpMethod> listOpMethod = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                  orderby item.Method_No
                                                                  where item.Method_No != 1 && item.Method_No != 8 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                  select item).ToList());
            listOpMethod.Insert(0, new T_OpMethod());
            comboBox_CalculateNo.DataSource = null;
            comboBox_CalculateNo.DataSource = listOpMethod;
            comboBox_CalculateNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
            comboBox_CalculateNo.ValueMember = "Method_No";
            comboBox_CalculateNo.SelectedValueChanged += comboBox_CalculateNo_SelectedValueChanged;
            List<T_Contract> listContract = new List<T_Contract>(db.T_Contracts.Select((T_Contract item) => item).ToList());
            listContract.Insert(0, new T_Contract());
            comboBox_ContrTyp.DataSource = null;
            comboBox_ContrTyp.DataSource = listContract;
            comboBox_ContrTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_ContrTyp.ValueMember = "Contract_No";
            List<T_Insurance> listInsuranceTyp = new List<T_Insurance>(db.T_Insurances.Select((T_Insurance item) => item).ToList());
            listInsuranceTyp.Insert(0, new T_Insurance());
            comboBox_InsuranceType.DataSource = null;
            comboBox_InsuranceType.DataSource = listInsuranceTyp;
            comboBox_InsuranceType.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_InsuranceType.ValueMember = "Insurance_No";
            List<T_Boss> listBoss = new List<T_Boss>(db.T_Bosses.Select((T_Boss item) => item).ToList());
            listBoss.Insert(0, new T_Boss());
            comboBox_DirBoss.DataSource = null;
            comboBox_DirBoss.DataSource = listBoss;
            comboBox_DirBoss.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_DirBoss.ValueMember = "Boss_No";
        }
        private void comboBox_CalculateNo_SelectedValueChanged(object sender, EventArgs e)
        {
            CalcAddSub();
        }
        private void CalcAddSub()
        {
            if (comboBox_CalculateNo.SelectedIndex <= 0 || (State != FormState.Edit && State != FormState.New))
            {
                return;
            }
            try
            {
                double vHour = 0.0;
                double vDay = 0.0;
                if (textBox_DayOfMonth.Value <= 0 || !(textBox_WorkHours.Value > 0.0))
                {
                    return;
                }
                switch (comboBox_CalculateNo.SelectedIndex)
                {
                    case 1:
                        vDay = Math.Round(textBox_MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                    case 2:
                        if (textBox_HousingAllowance.Value > 0.0)
                        {
                            vDay = Math.Round((textBox_HousingAllowance.Value / 12.0 + textBox_MainSal.Value) / (double)textBox_DayOfMonth.Value, 2);
                            vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        }
                        else
                        {
                            vDay = Math.Round(textBox_MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                            vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        }
                        break;
                    case 3:
                        if (textBox_HousingAllowance.Value > 0.0)
                        {
                            vDay = textBox_HousingAllowance.Value / 12.0;
                        }
                        vDay += textBox_MainSal.Value;
                        vDay = vDay + textBox_TransferAllowance.Value + textBox_SubsistenceAllowance.Value + textBox_NaturalWorkAllowance.Value + textBox_OtherAllowance.Value;
                        vDay = Math.Round(vDay / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                    case 4:
                        if (textBox_HousingAllowance.Value > 0.0)
                        {
                            vDay = textBox_HousingAllowance.Value / 12.0;
                        }
                        vDay += textBox_MainSal.Value;
                        vDay += textBox_TransferAllowance.Value;
                        vDay = Math.Round(vDay / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                    case 5:
                        vDay = textBox_MainSal.Value;
                        vDay += textBox_SubsistenceAllowance.Value;
                        vDay = Math.Round(vDay / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                    case 6:
                        vDay = textBox_MainSal.Value;
                        vDay += textBox_TransferAllowance.Value;
                        vDay = Math.Round(vDay / (double)textBox_DayOfMonth.Value, 2);
                        vHour = Math.Round(vDay / textBox_WorkHours.Value, 2);
                        break;
                }
                textBox_AddHours.Value = Math.Round(vHour, 2);
                textBox_LateHours.Value = Math.Round(textBox_AddHours.Value, 2);
                textBox_AddDay.Value = Math.Round(vDay, 2);
                textBox_DisOneDay.Value = textBox_AddDay.Value;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmEmp_CalcAddSub:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void comboBox_Nationalty_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Nationalty.Items.Count > 0 && comboBox_Nationalty.SelectedIndex > 0 && (State == FormState.New || State == FormState.Edit))
                {
                    List<T_Nationality> listNationality = new List<T_Nationality>(db.T_Nationalities.Where((T_Nationality item) => item.Nation_No == int.Parse(comboBox_Nationalty.SelectedValue.ToString())).ToList());
                    if (listNationality.Count > 0)
                    {
                        textBox_SocialInsurance.Value = listNationality.FirstOrDefault().SalSubtract.Value;
                        textBox_SocialInsuranceComp.Value = listNationality.FirstOrDefault().CompPaying.Value;
                    }
                }
            }
            catch
            {
                textBox_SocialInsurance.Value = 0.0;
                textBox_SocialInsuranceComp.Value = 0.0;
            }
        }
        private void textBox_DayOfMonth_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.New && State == FormState.Edit && textBox_DayOfMonth.Value > 0)
            {
                textBox_AddDay.Value = Math.Round(textBox_MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                textBox_DisOneDay.Value = textBox_AddDay.Value;
            }
        }
        private void textBox_WorkHours_ValueChanged(object sender, EventArgs e)
        {
            if ((State == FormState.Edit || State == FormState.New) && textBox_WorkHours.Value > 0.0)
            {
                textBox_AddHours.Value = Math.Round(textBox_AddDay.Value / textBox_WorkHours.Value, 2);
                textBox_LateHours.Value = textBox_AddHours.Value;
            }
        }
        private void textBox_TransferAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_HousingAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_MainSal_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_OtherAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_NaturalWorkAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_SubsistenceAllowance_KeyUp(object sender, KeyEventArgs e)
        {
            CalcAddSub();
        }
        private void textBox_AddDay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((State == FormState.Edit || State == FormState.New) && textBox_WorkHours.Value > 0.0)
                {
                    textBox_AddHours.Value = Math.Round(textBox_AddDay.Value / textBox_WorkHours.Value, 2);
                }
            }
            catch
            {
            }
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                T_Emp newData = db.EmpsEmpNo(textBox_ID.Text);
                if (newData == null || string.IsNullOrEmpty(newData.Emp_ID))
                {
                    if ((!Button_Add.Visible || !Button_Add.Enabled) && !buttonItem_EmpOut.Checked)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                    goto IL_0160;
                }
                DataThis = newData;
                int indexA = PKeys.IndexOf(newData.Emp_No ?? string.Empty);
                indexA++;
                TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                TextBox_Index.TextBox.Text = string.Concat(indexA);
                TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                goto IL_0160;
                IL_0160:
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_ID_TextChanged:", error, enable: true);
            }
        }
        public void SetData(T_Emp value)
        {
            State = FormState.Saved;
            Button_Save.Enabled = false;
            FillCombo();
            if (value.EmpPic != null)
            {
                byte[] arr = value.EmpPic.ToArray();
                MemoryStream stream = new MemoryStream(arr);
                pictureBox_EnterPic.Image = Image.FromStream(stream);
            }
            else
            {
                pictureBox_EnterPic.Image = null;
            }
            textBox_ID.Tag = value.Emp_ID;
            textBox_Pass.Text = VarGeneral.Decrypt(value.Pass);
            textBox_NameA.Text = value.NameA;
            textBox_NameE.Text = value.NameE;
            textBox_Note.Text = value.Note;
            textBox_AddDay.Value = value.AddDay.Value;
            textBox_AddHours.Value = value.AddHours.Value;
            textBox_AddressA.Text = value.AddressA;
            textBox_DayOfMonth.Value = value.DayOfMonth.Value;
            textBox_DisOneDay.Value = value.DisOneDay.Value;
            textBox_Email.Text = value.Email;
            textBox_ExperiencesA.Text = value.ExperiencesA;
            textBox_Form_No.Text = value.Form_No;
            textBox_HousingAllowance.Value = value.HousingAllowance.Value;
            textBox_ID_No.Text = value.ID_No;
            textBox_Insurance_No.Text = value.Insurance_No;
            textBox_LateHours.Value = value.LateHours.Value;
            textBox_License_No.Text = value.License_No;
            textBox_MainSal.Value = value.MainSal.Value;
            textBox_MandateDay.Value = value.MandateDay.Value;
            textBox_NaturalWorkAllowance.Value = value.NaturalWorkAllowance.Value;
            textBox_OtherAllowance.Value = value.OtherAllowance.Value;
            textBox_Passport_No.Text = value.Passport_No;
            textBox_QualificationA.Text = value.QualificationA;
            textBox_SocialInsuranceComp.Value = value.SocialInsuranceComp.Value;
            textBox_SocialInsurance.Value = value.SocialInsurance.Value;
            textBox_InsuranceMedicalCom.Value = value.InsuranceMedicalCom.Value;
            textBox_InsuranceMedical.Value = value.InsuranceMedical.Value;
            textBox_SocialInsuranceNo.Text = value.SocialInsuranceNo;
            textBox_WorkNo.Text = value.WorkNo;
            textBox_VisaNo.Text = value.VisaNo;
            textBox_VisaEnterNo.Text = value.VisaEnterNo;
            textBox_VisaCountry.Text = value.VisaCountry;
            textBox_SubsistenceAllowance.Value = value.SubsistenceAllowance.Value;
            textBox_Tel.Text = value.Tel;
            textBox_TicketsBalance.Value = value.TicketsBalance.Value;
            textBox_TicketsCount.Value = value.TicketsCount.Value;
            textBox_TicketsPrice.Value = value.TicketsPrice.Value;
            textBox_TransferAllowance.Value = value.TransferAllowance.Value;
            textBox_VacationBalance.Value = value.VacationBalance.Value;
            textBox_VacationCount.Value = value.VacationCount.Value;
            textBox_WorkHours.Value = value.WorkHours.Value;
            checkBox_AutoReturnContr.Checked = value.AutoReturnContr.Value;
            if (value.BirthPlace.HasValue)
            {
                comboBox_BirthPlace.SelectedValue = value.BirthPlace.Value;
            }
            if (value.BloodTyp.HasValue)
            {
                comboBox_BloodTyp.SelectedValue = value.BloodTyp.Value;
            }
            if (value.CalculateNo.HasValue)
            {
                comboBox_CalculateNo.SelectedValue = value.CalculateNo.Value;
            }
            if (value.CityNo.HasValue)
            {
                comboBox_CityNo.SelectedValue = value.CityNo.Value;
            }
            if (value.ContrTyp.HasValue)
            {
                comboBox_ContrTyp.SelectedValue = value.ContrTyp.Value;
            }
            if (value.Dept.HasValue)
            {
                comboBox_Dept.SelectedValue = value.Dept.Value;
            }
            if (value.DirBoss.HasValue)
            {
                comboBox_DirBoss.SelectedValue = value.DirBoss.Value;
            }
            if (value.Form_From.HasValue)
            {
                comboBox_Form_From.SelectedValue = value.Form_From.Value;
            }
            if (value.Guarantor.HasValue)
            {
                comboBox_Guarantor.SelectedValue = value.Guarantor.Value;
            }
            if (value.ID_From.HasValue)
            {
                comboBox_ID_From.SelectedValue = value.ID_From.Value;
            }
            if (value.Insurance_From.HasValue)
            {
                comboBox_Insurance_From.SelectedValue = value.Insurance_From.Value;
            }
            if (value.Job.HasValue)
            {
                comboBox_Job.SelectedValue = value.Job.Value;
            }
            if (value.License_From.HasValue)
            {
                comboBox_License_From.SelectedValue = value.License_From.Value;
            }
            if (value.MaritalStatus.HasValue)
            {
                comboBox_MaritalStatus.SelectedValue = value.MaritalStatus.Value;
            }
            if (value.Nationalty.HasValue)
            {
                comboBox_Nationalty.SelectedValue = value.Nationalty.Value;
            }
            if (value.Passport_From.HasValue)
            {
                comboBox_Passport_From.SelectedValue = value.Passport_From.Value;
            }
            if (value.Religion.HasValue)
            {
                comboBox_Religion.SelectedValue = value.Religion.Value;
            }
            if (value.Section.HasValue)
            {
                comboBox_Section.SelectedValue = value.Section.Value;
            }
            if (value.Sex.HasValue)
            {
                comboBox_Sex.SelectedValue = value.Sex.Value;
            }
            if (value.InsuranceNo.HasValue)
            {
                comboBox_InsuranceType.SelectedValue = value.InsuranceNo.Value;
            }
            textBox_Insurance_Class.Text = value.Insurance_Name;
            if (value.StatusSal.HasValue)
            {
                if (value.StatusSal.Value == 1)
                {
                    switchButton_SalStatus.Value = true;
                }
                else
                {
                    switchButton_SalStatus.Value = false;
                }
            }
            if (value.FatherA == "1")
            {
                switchButton_AccType.Value = true;
            }
            else
            {
                switchButton_AccType.Value = false;
            }
            try
            {
                if (VarGeneral.CheckDate(value.DateAppointment))
                {
                    dateTimeInput_DateAppointment.Text = Convert.ToDateTime(value.DateAppointment).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateAppointment.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_DateAppointment.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.BirthDate))
                {
                    dateTimeInput_BirthDate.Text = Convert.ToDateTime(value.BirthDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_BirthDate.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_BirthDate.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.VisaDate))
                {
                    dateTimeInput_VisaDate.Text = Convert.ToDateTime(value.VisaDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_VisaDate.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_VisaDate.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.StartContr))
                {
                    dateTimeInput_StartContr.Text = Convert.ToDateTime(value.StartContr).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_StartContr.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_StartContr.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.EndContr))
                {
                    dateTimeInput_EndContr.Text = Convert.ToDateTime(value.EndContr).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_EndContr.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_EndContr.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Form_Date))
                {
                    dateTimeInput_Form_Date.Text = Convert.ToDateTime(value.Form_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Form_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Form_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Form_DateEnd))
                {
                    dateTimeInput_Form_DateEnd.Text = Convert.ToDateTime(value.Form_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Form_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Form_DateEnd.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.ID_Date))
                {
                    dateTimeInput_ID_Date.Text = Convert.ToDateTime(value.ID_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_ID_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_ID_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.ID_DateEnd))
                {
                    dateTimeInput_ID_DateEnd.Text = Convert.ToDateTime(value.ID_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_ID_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_ID_DateEnd.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Insurance_Date))
                {
                    dateTimeInput_Insurance_Date.Text = Convert.ToDateTime(value.Insurance_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Insurance_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Insurance_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Insurance_DateEnd))
                {
                    dateTimeInput_Insurance_DateEnd.Text = Convert.ToDateTime(value.Insurance_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Insurance_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Insurance_DateEnd.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.LastFilter))
                {
                    dateTimeInput_LastFilter.Text = Convert.ToDateTime(value.LastFilter).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_LastFilter.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_LastFilter.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.LastFilter))
                {
                    dateTimeInput_License_Date.Text = Convert.ToDateTime(value.License_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_License_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_License_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.License_DateEnd))
                {
                    dateTimeInput_License_DateEnd.Text = Convert.ToDateTime(value.License_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_License_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_License_DateEnd.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Passport_Date))
                {
                    dateTimeInput_Pass_Date.Text = Convert.ToDateTime(value.Passport_Date).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Pass_Date.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Pass_Date.Text = string.Empty;
            }
            try
            {
                if (VarGeneral.CheckDate(value.Passport_DateEnd))
                {
                    dateTimeInput_Passport_DateEnd.Text = Convert.ToDateTime(value.Passport_DateEnd).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_Passport_DateEnd.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_Passport_DateEnd.Text = string.Empty;
            }
            try
            {
                if (!string.IsNullOrEmpty(value.Allowances.Value.ToString() ?? string.Empty))
                {
                    for (int i = 0; i < comboBox_Allowances.Items.Count; i++)
                    {
                        comboBox_Allowances.SelectedIndex = i;
                        if (comboBox_Allowances.Text == value.Allowances.Value.ToString())
                        {
                            break;
                        }
                    }
                }
            }
            catch
            {
                comboBox_Allowances.SelectedIndex = 0;
            }
            if (value.AllowancesTime.HasValue)
            {
                comboBox_AllowancesTime.SelectedIndex = value.AllowancesTime.Value;
            }
            if (!string.IsNullOrEmpty(value.SalAcc))
            {
                textBox_AccSal.Text = value.SalAcc;
                textBox_AccSalName.Text = ((LangArEn == 0) ? value.T_AccDef4.Arb_Des : value.T_AccDef4.Eng_Des);
            }
            else
            {
                textBox_AccSal.Text = string.Empty;
                textBox_AccSalName.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(value.LoanAcc))
            {
                textBox_AccLoan.Text = value.LoanAcc;
                textBox_AccLoanName.Text = ((LangArEn == 0) ? value.T_AccDef3.Arb_Des : value.T_AccDef3.Eng_Des);
            }
            else
            {
                textBox_AccLoan.Text = string.Empty;
                textBox_AccLoanName.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(value.HouseAcc))
            {
                textBox_AccHousing.Text = value.HouseAcc;
                textBox_AccHousingName.Text = ((LangArEn == 0) ? value.T_AccDef2.Arb_Des : value.T_AccDef2.Eng_Des);
            }
            else
            {
                textBox_AccHousing.Text = string.Empty;
                textBox_AccHousingName.Text = string.Empty;
            }
            if (value.CostCenterEmp.HasValue)
            {
                textBox_CostCenter.Text = value.CostCenterEmp.Value.ToString();
                textBox_CostCenterName.Text = ((LangArEn == 0) ? value.T_CstTbl.Arb_Des : value.T_CstTbl.Eng_Des);
            }
            else
            {
                textBox_CostCenter.Text = string.Empty;
                textBox_CostCenterName.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(value.AccountID))
            {
                txtBXBankNo.Text = value.AccountID;
                txtBXBankName.Text = ((LangArEn == 0) ? value.T_AccDef.Arb_Des : value.T_AccDef.Eng_Des);
            }
            else
            {
                txtBXBankNo.Text = string.Empty;
                txtBXBankName.Text = string.Empty;
            }
            BindingList<T_Family> Family_line = new BindingList<T_Family>(value.T_Families);
            FillFamilyBox(Family_line);
            try
            {
                Update_Attend = new BindingList<T_Attend>(value.T_Attends);
                FillAttendBox(Update_Attend);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FormEmpOn_FillAttendBox:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            try
            {
                FillImageList();
            }
            catch
            {
            }
            try
            {
                FillImageList2();
            }
            catch
            {
            }
            textBox_SocialInsuranceNo_Leave(null, null);
            textBox_WorkNo_Leave(null, null);
            SetReadOnly = true;
        }
        private void FillAttendBox(BindingList<T_Attend> linesList)
        {
            if (linesList.Count > 0)
            {
                textBox_SatTime1.Text = linesList[0].Time1;
                textBox_SatTime2.Text = linesList[0].Time2;
                textBox_SatTimeAllow1.Text = linesList[0].TimeAllow1;
                textBox_SatTimeAllow2.Text = linesList[0].TimeAlow2;
                textBox_SatLeaveTime1.Text = linesList[0].LeaveTime1;
                textBox_SatLeaveTime2.Text = linesList[0].LeaveTime2;
                if (linesList[0].Periods == 1)
                {
                    radioButton_SatPeriods1.Checked = true;
                }
                else if (linesList[0].Periods == 2)
                {
                    radioButton_SatPeriods2.Checked = true;
                }
                else
                {
                    radioButton_SatBreakDay.Checked = true;
                }
                textBox_SunTime1.Text = linesList[1].Time1;
                textBox_SunTime2.Text = linesList[1].Time2;
                textBox_SunTimeAllow1.Text = linesList[1].TimeAllow1;
                textBox_SunTimeAllow2.Text = linesList[1].TimeAlow2;
                textBox_SunLeaveTime1.Text = linesList[1].LeaveTime1;
                textBox_SunLeaveTime2.Text = linesList[1].LeaveTime2;
                if (linesList[1].Periods == 1)
                {
                    radioButton_SunPeriods1.Checked = true;
                }
                else if (linesList[1].Periods == 2)
                {
                    radioButton_SunPeriods2.Checked = true;
                }
                else
                {
                    radioButton_SunBreakDay.Checked = true;
                }
                textBox_MonTime1.Text = linesList[2].Time1;
                textBox_MonTime2.Text = linesList[2].Time2;
                textBox_MonTimeAllow1.Text = linesList[2].TimeAllow1;
                textBox_MonTimeAllow2.Text = linesList[2].TimeAlow2;
                textBox_MonLeaveTime1.Text = linesList[2].LeaveTime1;
                textBox_MonLeaveTime2.Text = linesList[2].LeaveTime2;
                if (linesList[2].Periods == 1)
                {
                    radioButton_MonPeriods1.Checked = true;
                }
                else if (linesList[2].Periods == 2)
                {
                    radioButton_MonPeriods2.Checked = true;
                }
                else
                {
                    radioButton_MonBreakDay.Checked = true;
                }
                textBox_TusTime1.Text = linesList[3].Time1;
                textBox_TusTime2.Text = linesList[3].Time2;
                textBox_TusTimeAllow1.Text = linesList[3].TimeAllow1;
                textBox_TusTimeAllow2.Text = linesList[3].TimeAlow2;
                textBox_TusLeaveTime1.Text = linesList[3].LeaveTime1;
                textBox_TusLeaveTime2.Text = linesList[3].LeaveTime2;
                if (linesList[3].Periods == 1)
                {
                    radioButton_TusPeriods1.Checked = true;
                }
                else if (linesList[3].Periods == 2)
                {
                    radioButton_TusPeriods2.Checked = true;
                }
                else
                {
                    radioButton_TusBreakDay.Checked = true;
                }
                textBox_WenTime1.Text = linesList[4].Time1;
                textBox_WenTime2.Text = linesList[4].Time2;
                textBox_WenTimeAllow1.Text = linesList[4].TimeAllow1;
                textBox_WenTimeAllow2.Text = linesList[4].TimeAlow2;
                textBox_WenLeaveTime1.Text = linesList[4].LeaveTime1;
                textBox_WenLeaveTime2.Text = linesList[4].LeaveTime2;
                if (linesList[4].Periods == 1)
                {
                    radioButton_WenPeriods1.Checked = true;
                }
                else if (linesList[4].Periods == 2)
                {
                    radioButton_WenPeriods2.Checked = true;
                }
                else
                {
                    radioButton_WenBreakDay.Checked = true;
                }
                textBox_ThurTime1.Text = linesList[5].Time1;
                textBox_ThurTime2.Text = linesList[5].Time2;
                textBox_ThurTimeAllow1.Text = linesList[5].TimeAllow1;
                textBox_ThurTimeAllow2.Text = linesList[5].TimeAlow2;
                textBox_ThurLeaveTime1.Text = linesList[5].LeaveTime1;
                textBox_ThurLeaveTime2.Text = linesList[5].LeaveTime2;
                if (linesList[5].Periods == 1)
                {
                    radioButton_ThurPeriods1.Checked = true;
                }
                else if (linesList[5].Periods == 2)
                {
                    radioButton_ThurPeriods2.Checked = true;
                }
                else
                {
                    radioButton_ThurBreakDay.Checked = true;
                }
                textBox_FriTime1.Text = linesList[6].Time1;
                textBox_FriTime2.Text = linesList[6].Time2;
                textBox_FriTimeAllow1.Text = linesList[6].TimeAllow1;
                textBox_FriTimeAllow2.Text = linesList[6].TimeAlow2;
                textBox_LeaveTime1.Text = linesList[6].LeaveTime1;
                textBox_LeaveTime2.Text = linesList[6].LeaveTime2;
                if (linesList[6].Periods == 1)
                {
                    radioButton_FriPeriods1.Checked = true;
                }
                else if (linesList[6].Periods == 2)
                {
                    radioButton_FriPeriods2.Checked = true;
                }
                else
                {
                    radioButton_FriBreakDay.Checked = true;
                }
            }
        }
        private void FillFamilyBox(BindingList<T_Family> linesList)
        {
            if (linesList.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < linesList.Count; i++)
            {
                if (i == 0)
                {
                    textBox_Name1.Text = linesList[i].Name;
                    textBox_Relation1.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate1.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate1.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd1.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd1.Text = string.Empty;
                    }
                    textBox_PassporntNo1.Text = linesList[i].PassNo;
                }
                if (i == 1)
                {
                    textBox_Name2.Text = linesList[i].Name;
                    textBox_Relation2.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate2.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate2.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd2.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd2.Text = string.Empty;
                    }
                    textBox_PassporntNo2.Text = linesList[i].PassNo;
                }
                if (i == 2)
                {
                    textBox_Name3.Text = linesList[i].Name;
                    textBox_Relation3.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate3.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate3.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd3.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd3.Text = string.Empty;
                    }
                    textBox_PassporntNo3.Text = linesList[i].PassNo;
                }
                if (i == 3)
                {
                    textBox_Name4.Text = linesList[i].Name;
                    textBox_Relation4.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate4.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate4.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd4.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd4.Text = string.Empty;
                    }
                    textBox_PassporntNo4.Text = linesList[i].PassNo;
                }
                if (i == 4)
                {
                    textBox_Name5.Text = linesList[i].Name;
                    textBox_Relation5.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate5.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate5.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd5.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd5.Text = string.Empty;
                    }
                    textBox_PassporntNo5.Text = linesList[i].PassNo;
                }
                if (i == 5)
                {
                    textBox_Name6.Text = linesList[i].Name;
                    textBox_Relation6.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate6.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate6.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = string.Empty;
                    }
                    textBox_PassporntNo6.Text = linesList[i].PassNo;
                }
                if (i == 6)
                {
                    textBox_Name7.Text = linesList[i].Name;
                    textBox_Relation7.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate7.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate7.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = string.Empty;
                    }
                    textBox_PassporntNo7.Text = linesList[i].PassNo;
                }
                if (i == 7)
                {
                    textBox_Name8.Text = linesList[i].Name;
                    textBox_Relation8.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate8.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate8.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd6.Text = string.Empty;
                    }
                    textBox_PassporntNo8.Text = linesList[i].PassNo;
                }
                if (i == 8)
                {
                    textBox_Name9.Text = linesList[i].Name;
                    textBox_Relation9.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate9.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate9.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd9.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd9.Text = string.Empty;
                    }
                    textBox_PassporntNo9.Text = linesList[i].PassNo;
                }
                if (i == 9)
                {
                    textBox_Name10.Text = linesList[i].Name;
                    textBox_Relation10.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate10.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate10.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd10.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd10.Text = string.Empty;
                    }
                    textBox_PassporntNo10.Text = linesList[i].PassNo;
                }
                if (i == 10)
                {
                    textBox_Name11.Text = linesList[i].Name;
                    textBox_Relation11.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate11.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate11.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd11.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd11.Text = string.Empty;
                    }
                    textBox_PassporntNo11.Text = linesList[i].PassNo;
                }
                if (i == 11)
                {
                    textBox_Name12.Text = linesList[i].Name;
                    textBox_Relation12.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate12.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate12.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd12.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd12.Text = string.Empty;
                    }
                    textBox_PassporntNo12.Text = linesList[i].PassNo;
                }
                if (i == 12)
                {
                    textBox_Name13.Text = linesList[i].Name;
                    textBox_Relation13.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate13.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate13.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd13.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd13.Text = string.Empty;
                    }
                    textBox_PassporntNo13.Text = linesList[i].PassNo;
                }
                if (i == 13)
                {
                    textBox_Name14.Text = linesList[i].Name;
                    textBox_Relation14.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate14.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate14.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd14.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd14.Text = string.Empty;
                    }
                    textBox_PassporntNo14.Text = linesList[i].PassNo;
                }
                if (i == 14)
                {
                    textBox_Name15.Text = linesList[i].Name;
                    textBox_Relation15.Text = linesList[i].Link;
                    try
                    {
                        dateTimeInput_BirthDate15.Text = Convert.ToDateTime(linesList[i].BirthDay).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_BirthDate15.Text = string.Empty;
                    }
                    try
                    {
                        dateTimeInput_PassportDateEnd15.Text = Convert.ToDateTime(linesList[i].PassEnd).ToString("yyyy/MM/dd");
                    }
                    catch
                    {
                        dateTimeInput_PassportDateEnd15.Text = string.Empty;
                    }
                    textBox_PassporntNo15.Text = linesList[i].PassNo;
                }
            }
        }
        private byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }
        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            System.IO.SearchOption searchOption = (isRecursive ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly);
            filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.*", searchOption));
            return filesFound.ToArray();
        }
        private void FillImageList()
        {
            try
            {
                listBox_ImageFiles.Items.Clear();
            }
            catch
            {
            }
            try
            {
                listBox_ImageFiles.DataSource = null;
            }
            catch
            {
            }
            try
            {
                string[] filters = new string[15]
                {
                    "jpeg",
                    "docx",
                    "BMP",
                    "JPG",
                    "GIF",
                    "PNG",
                    "TIF",
                    "PDF",
                    "PCX",
                    "TGA",
                    "JP2",
                    "JPC",
                    "RAS",
                    "PGX",
                    "PNM"
                };
                string[] filePaths = GetFilesFrom(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\EmpDocuments") : VarGeneral.Settings_Sys.DocumentPath, filters, isRecursive: false);
                if (filePaths.Count() <= 0)
                {
                    return;
                }
                for (int i = 0; i < filePaths.Count(); i++)
                {
                    try
                    {
                        if (Path.GetFileName(filePaths[i]).StartsWith(data_this.Emp_No))
                        {
                            listBox_ImageFiles.Items.Add(Path.GetFileName(filePaths[i]));
                        }
                    }
                    catch
                    {
                    }
                }
                listBox_ImageFiles.Sorted = true;
            }
            catch
            {
            }
        }
        private void FillImageList2()
        {
            try
            {
                listBox_ImageFiles2.Items.Clear();
            }
            catch
            {
            }
            try
            {
                listBox_ImageFiles2.DataSource = null;
            }
            catch
            {
            }
            try
            {
                string[] filters = new string[15]
                {
                    "jpeg",
                    "docx",
                    "BMP",
                    "JPG",
                    "GIF",
                    "PNG",
                    "TIF",
                    "PDF",
                    "PCX",
                    "TGA",
                    "JP2",
                    "JPC",
                    "RAS",
                    "PGX",
                    "PNM"
                };
                string[] filePaths = GetFilesFrom(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\EmpDocuments") : VarGeneral.Settings_Sys.DocumentPath, filters, isRecursive: false);
                if (filePaths.Count() <= 0)
                {
                    return;
                }
                for (int i = 0; i < filePaths.Count(); i++)
                {
                    try
                    {
                        if (!Path.GetFileName(filePaths[i]).StartsWith(data_this.Emp_No))
                        {
                            continue;
                        }
                        for (int iicnt = 0; iicnt < Path.GetFileName(filePaths[i]).Length; iicnt++)
                        {
                            try
                            {
                                if (Path.GetFileName(filePaths[i]).Substring(iicnt, 1) == "-" && Information.IsNumeric(Path.GetFileName(filePaths[i]).Substring(iicnt + 1, 5)) && Path.GetFileName(filePaths[i]).Substring(iicnt + 1, 5).Length == 5)
                                {
                                    listBox_ImageFiles2.Items.Add(Path.GetFileName(filePaths[i]).Substring(iicnt + 1, 5));
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                listBox_ImageFiles2.Sorted = true;
            }
            catch
            {
            }
        }
        private void TextBox_Index_InputTextChanged(object sender)
        {
            int index = 0;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
            }
            if (index <= PKeys.Count && index > 0)
            {
                textBox_ID.Text = PKeys[index - 1];
            }
        }
        private T_Emp GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.Emp_No = textBox_ID.Text;
            }
            catch
            {
            }
            try
            {
                data_this.NameA = textBox_NameA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.NameE = textBox_NameE.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Note = textBox_Note.Text;
            }
            catch
            {
            }
            try
            {
                data_this.AddDay = textBox_AddDay.Value;
            }
            catch
            {
                data_this.AddDay = 0.0;
            }
            try
            {
                data_this.AddHours = textBox_AddHours.Value;
            }
            catch
            {
                data_this.AddHours = 0.0;
            }
            try
            {
                data_this.AddressA = textBox_AddressA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.DayOfMonth = textBox_DayOfMonth.Value;
            }
            catch
            {
                data_this.DayOfMonth = 0;
            }
            try
            {
                data_this.DisOneDay = textBox_DisOneDay.Value;
            }
            catch
            {
                data_this.DisOneDay = 0.0;
            }
            try
            {
                data_this.Email = textBox_Email.Text;
            }
            catch
            {
            }
            try
            {
                data_this.EmpState = VarGeneral.FrmEmpStat;
            }
            catch
            {
                data_this.EmpState = true;
            }
            try
            {
                data_this.ExperiencesA = textBox_ExperiencesA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Form_No = textBox_Form_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.HousingAllowance = textBox_HousingAllowance.Value;
            }
            catch
            {
                data_this.HousingAllowance = 0.0;
            }
            try
            {
                data_this.ID_No = textBox_ID_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Insurance_No = textBox_Insurance_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.LateHours = textBox_LateHours.Value;
            }
            catch
            {
                data_this.LateHours = 0.0;
            }
            try
            {
                data_this.License_No = textBox_License_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.MainSal = textBox_MainSal.Value;
            }
            catch
            {
                data_this.MainSal = 0.0;
            }
            try
            {
                data_this.MandateDay = textBox_MandateDay.Value;
            }
            catch
            {
                data_this.MandateDay = 0.0;
            }
            try
            {
                data_this.NaturalWorkAllowance = textBox_NaturalWorkAllowance.Value;
            }
            catch
            {
                data_this.NaturalWorkAllowance = 0.0;
            }
            try
            {
                data_this.OtherAllowance = textBox_OtherAllowance.Value;
            }
            catch
            {
                data_this.OtherAllowance = 0.0;
            }
            try
            {
                data_this.Pass = VarGeneral.Encrypt(textBox_Pass.Text);
            }
            catch
            {
            }
            try
            {
                data_this.Passport_No = textBox_Passport_No.Text;
            }
            catch
            {
            }
            try
            {
                data_this.QualificationA = textBox_QualificationA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.SocialInsurance = textBox_SocialInsurance.Value;
            }
            catch
            {
                data_this.SocialInsurance = 0.0;
            }
            try
            {
                data_this.SocialInsuranceComp = textBox_SocialInsuranceComp.Value;
            }
            catch
            {
                data_this.SocialInsuranceComp = 0.0;
            }
            try
            {
                data_this.InsuranceMedicalCom = textBox_InsuranceMedicalCom.Value;
            }
            catch
            {
                data_this.InsuranceMedicalCom = 0.0;
            }
            try
            {
                data_this.InsuranceMedical = textBox_InsuranceMedical.Value;
            }
            catch
            {
                data_this.InsuranceMedical = 0.0;
            }
            try
            {
                data_this.SocialInsuranceNo = textBox_SocialInsuranceNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.WorkNo = textBox_WorkNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.VisaNo = textBox_VisaNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.VisaEnterNo = textBox_VisaEnterNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.VisaCountry = textBox_VisaCountry.Text;
            }
            catch
            {
            }
            try
            {
                data_this.SubsistenceAllowance = textBox_SubsistenceAllowance.Value;
            }
            catch
            {
                data_this.SubsistenceAllowance = 0.0;
            }
            try
            {
                data_this.Tel = textBox_Tel.Text;
            }
            catch
            {
            }
            try
            {
                data_this.TicketsCount = textBox_TicketsCount.Value;
            }
            catch
            {
                data_this.TicketsCount = 0.0;
            }
            try
            {
                data_this.TicketsPrice = textBox_TicketsPrice.Value;
            }
            catch
            {
                data_this.TicketsPrice = 0.0;
            }
            try
            {
                data_this.TransferAllowance = textBox_TransferAllowance.Value;
            }
            catch
            {
                data_this.TransferAllowance = 0.0;
            }
            try
            {
                data_this.VacationCount = textBox_VacationCount.Value;
            }
            catch
            {
                data_this.VacationCount = 0;
            }
            try
            {
                data_this.WorkHours = textBox_WorkHours.Value;
            }
            catch
            {
                data_this.WorkHours = 0.0;
            }
            try
            {
                data_this.AutoReturnContr = checkBox_AutoReturnContr.Checked;
            }
            catch
            {
            }
            try
            {
                data_this.DateAppointment = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DateAppointment.Text = string.Empty;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_DateAppointment.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateAppointment.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
                data_this.DateAppointment = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            try
            {
                data_this.StartContr = Convert.ToDateTime(dateTimeInput_StartContr.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_StartContr.Text = string.Empty;
                data_this.StartContr = string.Empty;
            }
            try
            {
                data_this.Insurance_Date = Convert.ToDateTime(dateTimeInput_Insurance_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Insurance_Date.Text = string.Empty;
                data_this.Insurance_Date = string.Empty;
            }
            try
            {
                data_this.VisaDate = Convert.ToDateTime(dateTimeInput_VisaDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_VisaDate.Text = string.Empty;
                data_this.VisaDate = string.Empty;
            }
            try
            {
                data_this.BirthDate = Convert.ToDateTime(dateTimeInput_BirthDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate.Text = string.Empty;
                data_this.BirthDate = string.Empty;
            }
            try
            {
                data_this.EndContr = Convert.ToDateTime(dateTimeInput_EndContr.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_EndContr.Text = string.Empty;
                data_this.EndContr = string.Empty;
            }
            try
            {
                data_this.Form_Date = Convert.ToDateTime(dateTimeInput_Form_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Form_Date.Text = string.Empty;
                data_this.Form_Date = string.Empty;
            }
            try
            {
                data_this.Form_DateEnd = Convert.ToDateTime(dateTimeInput_Form_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Form_DateEnd.Text = string.Empty;
                data_this.Form_DateEnd = string.Empty;
            }
            try
            {
                data_this.ID_Date = Convert.ToDateTime(dateTimeInput_ID_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ID_Date.Text = string.Empty;
                data_this.ID_Date = string.Empty;
            }
            try
            {
                if (!db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    data_this.ID_DateEnd = Convert.ToDateTime(dateTimeInput_ID_DateEnd.Text).ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                dateTimeInput_ID_DateEnd.Text = string.Empty;
                data_this.ID_DateEnd = string.Empty;
            }
            try
            {
                if (!db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    data_this.Insurance_DateEnd = Convert.ToDateTime(dateTimeInput_Insurance_DateEnd.Text).ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                dateTimeInput_Insurance_DateEnd.Text = string.Empty;
                data_this.Insurance_DateEnd = string.Empty;
            }
            try
            {
                data_this.LastFilter = Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_LastFilter.Text = string.Empty;
                data_this.LastFilter = string.Empty;
            }
            try
            {
                data_this.License_Date = Convert.ToDateTime(dateTimeInput_License_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_License_Date.Text = string.Empty;
                data_this.License_Date = string.Empty;
            }
            try
            {
                if (!db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    data_this.License_DateEnd = Convert.ToDateTime(dateTimeInput_License_DateEnd.Text).ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                dateTimeInput_License_DateEnd.Text = string.Empty;
                data_this.License_DateEnd = string.Empty;
            }
            try
            {
                data_this.Passport_Date = Convert.ToDateTime(dateTimeInput_Pass_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Pass_Date.Text = string.Empty;
                data_this.Passport_Date = string.Empty;
            }
            try
            {
                if (!db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    data_this.Passport_DateEnd = Convert.ToDateTime(dateTimeInput_Passport_DateEnd.Text).ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                dateTimeInput_Passport_DateEnd.Text = string.Empty;
                data_this.Passport_DateEnd = string.Empty;
            }
            if (pictureBox_EnterPic.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                pictureBox_EnterPic.Image.Save(stream, ImageFormat.Jpeg);
                byte[] arr = stream.GetBuffer();
                data_this.EmpPic = arr;
            }
            else
            {
                data_this.EmpPic = null;
            }
            try
            {
                if (comboBox_BirthPlace.SelectedIndex > 0)
                {
                    data_this.BirthPlace = int.Parse(comboBox_BirthPlace.SelectedValue.ToString());
                }
                else
                {
                    data_this.BirthPlace = null;
                }
            }
            catch
            {
                data_this.BirthPlace = null;
            }
            try
            {
                if (comboBox_BloodTyp.SelectedIndex > 0)
                {
                    data_this.BloodTyp = int.Parse(comboBox_BloodTyp.SelectedValue.ToString());
                }
                else
                {
                    data_this.BloodTyp = null;
                }
            }
            catch
            {
                data_this.BloodTyp = null;
            }
            try
            {
                if (comboBox_CalculateNo.SelectedIndex > 0)
                {
                    data_this.CalculateNo = int.Parse(comboBox_CalculateNo.SelectedValue.ToString());
                }
                else
                {
                    data_this.CalculateNo = null;
                }
            }
            catch
            {
                data_this.CalculateNo = null;
            }
            try
            {
                if (comboBox_CityNo.SelectedIndex > 0)
                {
                    data_this.CityNo = int.Parse(comboBox_CityNo.SelectedValue.ToString());
                }
                else
                {
                    data_this.CityNo = null;
                }
            }
            catch
            {
                data_this.CityNo = null;
            }
            try
            {
                if (comboBox_ContrTyp.SelectedIndex > 0)
                {
                    data_this.ContrTyp = int.Parse(comboBox_ContrTyp.SelectedValue.ToString());
                }
                else
                {
                    data_this.ContrTyp = null;
                }
            }
            catch
            {
                data_this.ContrTyp = null;
            }
            try
            {
                if (comboBox_Dept.SelectedIndex > 0)
                {
                    data_this.Dept = int.Parse(comboBox_Dept.SelectedValue.ToString());
                }
                else
                {
                    data_this.Dept = null;
                }
            }
            catch
            {
                data_this.Dept = null;
            }
            try
            {
                if (comboBox_DirBoss.SelectedIndex > 0)
                {
                    data_this.DirBoss = int.Parse(comboBox_DirBoss.SelectedValue.ToString());
                }
                else
                {
                    data_this.DirBoss = null;
                }
            }
            catch
            {
                data_this.DirBoss = null;
            }
            try
            {
                if (comboBox_Form_From.SelectedIndex > 0)
                {
                    data_this.Form_From = int.Parse(comboBox_Form_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.Form_From = null;
                }
            }
            catch
            {
                data_this.Form_From = null;
            }
            try
            {
                if (comboBox_Guarantor.SelectedIndex > 0)
                {
                    data_this.Guarantor = int.Parse(comboBox_Guarantor.SelectedValue.ToString());
                }
                else
                {
                    data_this.Guarantor = null;
                }
            }
            catch
            {
                data_this.Guarantor = null;
            }
            try
            {
                if (comboBox_ID_From.SelectedIndex > 0)
                {
                    data_this.ID_From = int.Parse(comboBox_ID_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.ID_From = null;
                }
            }
            catch
            {
                data_this.ID_From = null;
            }
            try
            {
                if (comboBox_Insurance_From.SelectedIndex > 0)
                {
                    data_this.Insurance_From = int.Parse(comboBox_Insurance_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.Insurance_From = null;
                }
            }
            catch
            {
                data_this.Insurance_From = null;
            }
            try
            {
                if (comboBox_Job.SelectedIndex > 0)
                {
                    data_this.Job = int.Parse(comboBox_Job.SelectedValue.ToString());
                }
                else
                {
                    data_this.Job = null;
                }
            }
            catch
            {
                data_this.Job = null;
            }
            try
            {
                if (comboBox_License_From.SelectedIndex > 0)
                {
                    data_this.License_From = int.Parse(comboBox_License_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.License_From = null;
                }
            }
            catch
            {
                data_this.License_From = null;
            }
            try
            {
                if (comboBox_MaritalStatus.SelectedIndex > 0)
                {
                    data_this.MaritalStatus = int.Parse(comboBox_MaritalStatus.SelectedValue.ToString());
                }
                else
                {
                    data_this.MaritalStatus = null;
                }
            }
            catch
            {
                data_this.MaritalStatus = null;
            }
            try
            {
                if (comboBox_Nationalty.SelectedIndex > 0)
                {
                    data_this.Nationalty = int.Parse(comboBox_Nationalty.SelectedValue.ToString());
                }
                else
                {
                    data_this.Nationalty = null;
                }
            }
            catch
            {
                data_this.Nationalty = null;
            }
            try
            {
                if (comboBox_Passport_From.SelectedIndex > 0)
                {
                    data_this.Passport_From = int.Parse(comboBox_Passport_From.SelectedValue.ToString());
                }
                else
                {
                    data_this.Passport_From = null;
                }
            }
            catch
            {
                data_this.Passport_From = null;
            }
            try
            {
                if (comboBox_Religion.SelectedIndex > 0)
                {
                    data_this.Religion = int.Parse(comboBox_Religion.SelectedValue.ToString());
                }
                else
                {
                    data_this.Religion = null;
                }
            }
            catch
            {
                data_this.Religion = null;
            }
            try
            {
                if (comboBox_Section.SelectedIndex > 0)
                {
                    data_this.Section = int.Parse(comboBox_Section.SelectedValue.ToString());
                }
                else
                {
                    data_this.Section = null;
                }
            }
            catch
            {
                data_this.Section = null;
            }
            try
            {
                if (comboBox_Sex.SelectedIndex > 0)
                {
                    data_this.Sex = int.Parse(comboBox_Sex.SelectedValue.ToString());
                }
                else
                {
                    data_this.Sex = null;
                }
            }
            catch
            {
                data_this.Sex = null;
            }
            try
            {
                if (switchButton_SalStatus.Value)
                {
                    data_this.StatusSal = 1;
                }
                else
                {
                    data_this.StatusSal = 2;
                }
            }
            catch
            {
                data_this.StatusSal = 2;
            }
            try
            {
                if (switchButton_AccType.Value)
                {
                    data_this.FatherA = "1";
                }
                else
                {
                    data_this.FatherA = "0";
                }
            }
            catch
            {
                data_this.FatherA = "1";
            }
            try
            {
                if (State == FormState.New)
                {
                    if (comboBox_InsuranceType.SelectedIndex > 0)
                    {
                        data_this.Insurance_Name = textBox_Insurance_Class.Text;
                    }
                    else
                    {
                        data_this.Insurance_Name = string.Empty;
                    }
                }
            }
            catch
            {
                data_this.Insurance_Name = string.Empty;
            }
            try
            {
                if (State == FormState.New)
                {
                    if (comboBox_InsuranceType.SelectedIndex > 0)
                    {
                        data_this.InsuranceNo = int.Parse(comboBox_InsuranceType.SelectedValue.ToString());
                    }
                    else
                    {
                        data_this.InsuranceNo = null;
                    }
                }
            }
            catch
            {
                data_this.InsuranceNo = null;
            }
            string vD = string.Empty;
            string vD2 = string.Empty;
            string vD3 = string.Empty;
            string vD4 = string.Empty;
            if (VarGeneral.CheckDate(dateTimeInput_LastFilter.Text))
            {
                vD = Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd");
            }
            if (VarGeneral.CheckDate(dateTimeInput_DateAppointment.Text))
            {
                vD2 = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            if (VarGeneral.CheckDate(dateTimeInput_EndContr.Text))
            {
                vD3 = Convert.ToDateTime(dateTimeInput_EndContr.Text).ToString("yyyy/MM/dd");
            }
            double TicketUse = 0.0;
            int VacUse = 0;
            TicketUse = db.ExecuteQuery<double>("select dbo.GetTickeUsed('" + data_this.Emp_ID + "')", new object[0]).FirstOrDefault();
            VacUse = db.ExecuteQuery<int>("select dbo.GetVacUsed('" + data_this.Emp_ID + "')", new object[0]).FirstOrDefault();
            vD4 = (VarGeneral.CheckDate(vD) ? vD : vD2);
            if (State == FormState.New)
            {
                textBox_TicketsBalance.Value = db.TicktAmount(vD2, n.IsGreg(vD2) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"), textBox_TicketsCount.Value) - TicketUse;
                textBox_VacationBalance.Value = db.VacAmount(vD2, n.IsGreg(vD2) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"), textBox_VacationCount.Value) - VacUse;
            }
            else
            {
                textBox_TicketsBalance.Value = db.TicktAmount(vD4, VarGeneral.CheckDate(vD3) ? vD3 : (n.IsGreg(vD4) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd")), textBox_TicketsCount.Value) - TicketUse;
                textBox_VacationBalance.Value = db.VacAmount(vD4, VarGeneral.CheckDate(vD3) ? vD3 : (n.IsGreg(vD4) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd")), textBox_VacationCount.Value) - VacUse;
            }
            try
            {
                data_this.VacationBalance = textBox_VacationBalance.Value;
            }
            catch
            {
                data_this.VacationBalance = 0.0;
            }
            try
            {
                data_this.TicketsBalance = textBox_TicketsBalance.Value;
            }
            catch
            {
                data_this.TicketsBalance = 0.0;
            }
            data_this.CompanyID = null;
            try
            {
                if (!string.IsNullOrEmpty(textBox_AccSal.Text))
                {
                    data_this.SalAcc = textBox_AccSal.Text;
                }
                else
                {
                    data_this.SalAcc = null;
                }
            }
            catch
            {
                data_this.SalAcc = null;
            }
            try
            {
                if (!string.IsNullOrEmpty(textBox_AccLoan.Text))
                {
                    data_this.LoanAcc = textBox_AccLoan.Text;
                }
                else
                {
                    data_this.LoanAcc = null;
                }
            }
            catch
            {
                data_this.LoanAcc = null;
            }
            try
            {
                if (!string.IsNullOrEmpty(textBox_AccHousing.Text))
                {
                    data_this.HouseAcc = textBox_AccHousing.Text;
                }
                else
                {
                    data_this.HouseAcc = null;
                }
            }
            catch
            {
                data_this.HouseAcc = null;
            }
            try
            {
                if (!string.IsNullOrEmpty(textBox_CostCenter.Text))
                {
                    data_this.CostCenterEmp = int.Parse(textBox_CostCenter.Text);
                }
                else
                {
                    data_this.CostCenterEmp = null;
                }
            }
            catch
            {
                data_this.CostCenterEmp = null;
            }
            if (switchButton_AccType.Value)
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtBXBankNo.Text))
                    {
                        data_this.AccountID = txtBXBankNo.Text;
                    }
                    else
                    {
                        data_this.AccountID = null;
                    }
                }
                catch
                {
                    data_this.AccountID = null;
                }
                data_this.BankBR = null;
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtBXBankNo.Text))
                    {
                        data_this.AccountID = txtBXBankNo.Text;
                    }
                    else
                    {
                        data_this.AccountID = null;
                    }
                }
                catch
                {
                    data_this.AccountID = null;
                }
                data_this.BankBR = null;
            }
            try
            {
                data_this.Allowances = int.Parse(comboBox_Allowances.Text);
            }
            catch
            {
                data_this.Allowances = 0;
            }
            try
            {
                data_this.AllowancesTime = comboBox_AllowancesTime.SelectedIndex;
            }
            catch
            {
                data_this.AllowancesTime = 0;
            }
            return data_this;
        }
        private void Save_DataAttend()
        {
            for (int i = 0; i <= 6; i++)
            {
                Datathis_Attend = new T_Attend();
                if (State == FormState.Edit)
                {
                    Data_this_Attend = Update_Attend[i];
                }
                switch (i)
                {
                    case 0:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_SatTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_SatTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_SatTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_SatTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_SatLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_SatLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_SatPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_SatPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 1:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_SunTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_SunTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_SunTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_SunTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_SunLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_SunLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_SunPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_SunPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 2:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_MonTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_MonTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_MonTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_MonTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_MonLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_MonLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_MonPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_MonPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 3:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_TusTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_TusTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_TusTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_TusTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_TusLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_TusLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_TusPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_TusPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 4:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_WenTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_WenTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_WenTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_WenTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_WenLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_WenLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_WenPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_WenPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 5:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_ThurTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_ThurTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_ThurTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_ThurTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_ThurLeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_ThurLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_ThurPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_ThurPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                    case 6:
                        try
                        {
                            Datathis_Attend.EmpID = textBox_ID.Tag.ToString();
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Day_No = i + 1;
                        }
                        catch
                        {
                        }
                        try
                        {
                            Datathis_Attend.Time1 = TimeSpan.Parse(textBox_FriTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.Time2 = TimeSpan.Parse(textBox_FriTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.Time2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAllow1 = TimeSpan.Parse(textBox_FriTimeAllow1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAllow1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.TimeAlow2 = TimeSpan.Parse(textBox_FriTimeAllow2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.TimeAlow2 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime1 = TimeSpan.Parse(textBox_LeaveTime1.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime1 = "__:__";
                        }
                        try
                        {
                            Datathis_Attend.LeaveTime2 = TimeSpan.Parse(textBox_ThurLeaveTime2.Text).ToString();
                        }
                        catch
                        {
                            Datathis_Attend.LeaveTime2 = "__:__";
                        }
                        if (radioButton_FriPeriods1.Checked)
                        {
                            Datathis_Attend.Periods = 1;
                        }
                        else if (radioButton_FriPeriods2.Checked)
                        {
                            Datathis_Attend.Periods = 2;
                        }
                        else
                        {
                            Datathis_Attend.Periods = 0;
                        }
                        break;
                }
                try
                {
                    if (State == FormState.New)
                    {
                        Guid Newid = Guid.NewGuid();
                        Data_this_Attend.Attend_ID = Newid.ToString();
                        db.T_Attends.InsertOnSubmit(Datathis_Attend);
                        db.SubmitChanges();
                    }
                    else
                    {
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("FormEmpOn_Save_DataAttend:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int max = 0;
                max = db.MaxEmpsNo;
                Clear();
                textBox_ID.Text = max.ToString();
                State = FormState.New;
            }
        }
        private bool ValidData()
        {
            try
            {
                if (int.Parse(textBox_ID.Text) <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? " خطأ,, الرجاء التأكد من رقم الموظف " : "error, please make sure of the Employee No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
            }
            catch
            {
            }
            if (!Button_Save.Enabled)
            {
                return false;
            }
            if (State == FormState.Edit && !CanEdit)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (State == FormState.New && !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (textBox_ID.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز" : "Can not be a number is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (textBox_NameA.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be a name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_NameA.Focus();
                return false;
            }
            if (textBox_NameE.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be a name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_NameE.Focus();
                return false;
            }
            T_Emp q = db.EmpsEmpNo(textBox_ID.Text);
            if (!string.IsNullOrEmpty(q.Emp_ID) && State == FormState.New)
            {
                MessageBox.Show((LangArEn == 0) ? " رقم الموظف مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (comboBox_CalculateNo.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى اختيار طريقة الخصم والاضافي قبل عملية الحفظ" : "Most Select Method Overtime and Deducion Before Save", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_CalculateNo.Focus();
                return false;
            }
            if (comboBox_ContrTyp.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى اختيار نوع العقد قبل عملية الحفظ" : "Most Select Contract Type Before Save", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_CalculateNo.Focus();
                return false;
            }
            if (comboBox_Dept.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون اسم الإدارة فارغا" : "Can not be a dept name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Dept.Focus();
                return false;
            }
            if (comboBox_Guarantor.SelectedIndex <= 0 && VarGeneral.Settings_Sys.Sponer.Value)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون اسم الكفيل فارغا" : "Can not be a Sponser name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Guarantor.Focus();
                return false;
            }
            if (comboBox_Job.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون اسم الوظيفة فارغا" : "Can not be a Job name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Job.Focus();
                return false;
            }
            if (comboBox_Section.SelectedIndex <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون اسم الفسم فارغا" : "Can not be a Section name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                comboBox_Section.Focus();
                return false;
            }
            if (textBox_DayOfMonth.Value <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد عدد الأيام/الشهر" : "Most Set days of month", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_DayOfMonth.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(dateTimeInput_DateAppointment.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "تحقق من تاريخ التعيين" : "Check the Apponintment Date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                dateTimeInput_DateAppointment.Focus();
                return false;
            }
            if (VarGeneral.CheckDate(dateTimeInput_StartContr.Text) && VarGeneral.CheckDate(dateTimeInput_EndContr.Text) && Convert.ToDateTime(dateTimeInput_EndContr.Text) < Convert.ToDateTime(dateTimeInput_StartContr.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ بداية ونهاية العقد " : "Start Date and End Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                dateTimeInput_EndContr.Text = string.Empty;
                dateTimeInput_StartContr.Focus();
                return false;
            }
            return true;
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (!ValidData())
                {
                    return;
                }
                try
                {
                    dateTimeInput_DateAppointment.Text = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "تحقق من تاريخ التعيين" : "Check the Apponintment Date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_DateAppointment.Focus();
                    return;
                }
                if (State == FormState.New)
                {
                    try
                    {
                        GetData();
                        data_this.Emp_ID = textBox_ID.Tag.ToString();
                        db.T_Emps.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                        Save_DataAttend();
                    }
                    catch (SqlException error2)
                    {
                        int max = 0;
                        max = db.MaxEmpsNo;
                        if (error2.Number == 2627)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("رقم الأمر مستخدم من قبل.\nسيتم الحفظ برقم جديد [" + max + "]") : ("This No is user before.\nWill be save a new number [" + max + "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            textBox_ID.TextChanged -= textBox_ID_TextChanged;
                            textBox_ID.Text = string.Concat(max);
                            textBox_ID.TextChanged += textBox_ID_TextChanged;
                            data_this.Emp_No = string.Concat(max);
                            Guid id = Guid.NewGuid();
                            data_this.Emp_ID = id.ToString();
                            textBox_ID.Tag = data_this.Emp_ID;
                            Button_Save_Click(sender, e);
                        }
                        else
                        {
                            VarGeneral.DebLog.writeLog("Button_Save_Click:", error2, enable: true);
                            MessageBox.Show(error2.Message);
                        }
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    string vEmpNo = data_this.Emp_No;
                    try
                    {
                        db.ExecuteCommand("Update T_Emp Set HouseAcc= null where Emp_ID='" + data_this.Emp_ID + "'");
                    }
                    catch
                    {
                    }
                    dbInstance = null;
                    data_this = db.EmpsEmp(data_this.Emp_ID);
                    GetData();
                    Refresh();
                    try
                    {
                        if (vEmpNo != data_this.Emp_No)
                        {
                            for (int i = 0; i < listBox_ImageFiles.Items.Count; i++)
                            {
                                try
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\EmpDocuments\\" + listBox_ImageFiles.Items[i]) : (VarGeneral.Settings_Sys.DocumentPath + "\\" + listBox_ImageFiles.Items[i]), data_this.Emp_No + listBox_ImageFiles.Items[i].ToString().Substring(vEmpNo.Length));
                                }
                                catch
                                {
                                }
                            }
                            FillImageList();
                        }
                    }
                    catch
                    {
                    }
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    Save_DataAttend();
                }
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.Emp_No ?? string.Empty) + 1);
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text))
                {
                    return;
                }
                if (!Button_Delete.Enabled || !Button_Delete.Visible)
                {
                    ifOkDelete = false;
                    return;
                }
                if (!checkEmpOperate(textBox_ID.Tag.ToString()))
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن حذف الموظف .. لان عليه حركات سابقة" : "You can not delete Employee ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    ifOkDelete = false;
                    return;
                }
                string Code = "???";
                if (codeControl != null)
                {
                    Code = codeControl.Text;
                }
                if (Code == string.Empty)
                {
                    ifOkDelete = false;
                    return;
                }
                if (MessageBox.Show("هل أنت متاكد من حذف السجل [" + Code + "]؟ \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ifOkDelete = true;
                }
                else
                {
                    ifOkDelete = false;
                }
                if (data_this == null || string.IsNullOrEmpty(data_this.Emp_ID) || !ifOkDelete)
                {
                    return;
                }
                data_this = db.EmpsEmp(DataThis.Emp_ID);
                if (db.CheckEmp_Attend(data_this.Emp_ID))
                {
                    db.T_Attends.DeleteAllOnSubmit(data_this.T_Attends);
                    db.SubmitChanges();
                }
                if (db.CheckEmp_AttendOpetation(data_this.Emp_ID))
                {
                    db.T_AttendOperats.DeleteAllOnSubmit(data_this.T_AttendOperats);
                    db.SubmitChanges();
                }
                if (db.CheckEmp_Family(textBox_ID.Tag.ToString()))
                {
                    db.T_Families.DeleteAllOnSubmit(data_this.T_Families);
                    db.SubmitChanges();
                }
                db.T_Advances.DeleteAllOnSubmit(data_this.T_Advances);
                db.SubmitChanges();
                db.T_Authorizations.DeleteAllOnSubmit(data_this.T_Authorizations);
                db.SubmitChanges();
                db.T_Rewards.DeleteAllOnSubmit(data_this.T_Rewards);
                db.SubmitChanges();
                db.T_SalDiscounts.DeleteAllOnSubmit(data_this.T_SalDiscounts);
                db.SubmitChanges();
                db.T_Tickets.DeleteAllOnSubmit(data_this.T_Tickets);
                db.SubmitChanges();
                db.T_Vacations.DeleteAllOnSubmit(data_this.T_Vacations);
                db.SubmitChanges();
                db.T_Adds.DeleteAllOnSubmit(data_this.T_Adds);
                db.SubmitChanges();
                db.T_Emps.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
                for (int i = 0; i < listBox_ImageFiles.Items.Count; i++)
                {
                    try
                    {
                        File.Delete(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\EmpDocuments\\" + listBox_ImageFiles.Items[i]) : (VarGeneral.Settings_Sys.DocumentPath + "\\" + listBox_ImageFiles.Items[i]));
                    }
                    catch
                    {
                    }
                }
                Clear();
                RefreshPKeys();
                textBox_ID.Text = PKeys.LastOrDefault();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Delete_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                DataThis = db.EmpsEmp(DataThis.Emp_ID);
            }
        }
        private bool checkEmpOperate(string value)
        {
            try
            {
                if (db.CheckEmp_Add(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Addvance(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Authorization(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Discount(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Reward(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Ticket(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_vacation(data_this.Emp_ID))
                {
                    return false;
                }
                if (db.CheckEmp_Salary(data_this.Emp_ID))
                {
                    return false;
                }
                return true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmEmpOn_checkEmpOperate:", error, enable: true);
                return false;
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Emp")
            {
                PropBranchPanel(panel);
            }
        }
        private void PropBranchPanel(GridPanel panel)
        {
            DGV_Main.PrimaryGrid.UseAlternateRowStyle = true;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color1 = Color.SkyBlue;
            panel.FrozenColumnCount = 1;
            panel.Columns[0].GroupBoxEffects = GroupBoxEffects.None;
            foreach (GridColumn column in panel.Columns)
            {
                column.ColumnSortMode = ColumnSortMode.Multiple;
            }
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                DGV_Main.PrimaryGrid.Columns[i].CellStyles.Default.Alignment = Alignment.MiddleCenter;
                DGV_Main.PrimaryGrid.Columns[i].Visible = false;
            }
            panel.Columns["Emp_No"].Width = 120;
            panel.Columns["Emp_No"].Visible = columns_Names_visible["Emp_No"].IfDefault;
            panel.Columns["NameA"].Width = 250;
            panel.Columns["NameA"].Visible = columns_Names_visible["NameA"].IfDefault;
            panel.Columns["NameE"].Width = 250;
            panel.Columns["NameE"].Visible = columns_Names_visible["NameE"].IfDefault;
            panel.Columns["StartContr"].Width = 100;
            panel.Columns["StartContr"].Visible = columns_Names_visible["StartContr"].IfDefault;
            panel.Columns["EndContr"].Width = 100;
            panel.Columns["EndContr"].Visible = columns_Names_visible["EndContr"].IfDefault;
            panel.Columns["MainSal"].Width = 150;
            panel.Columns["MainSal"].Visible = columns_Names_visible["MainSal"].IfDefault;
            panel.Columns["ID_No"].Width = 120;
            panel.Columns["ID_No"].Visible = columns_Names_visible["ID_No"].IfDefault;
            panel.Columns["Passport_No"].Width = 120;
            panel.Columns["Passport_No"].Visible = columns_Names_visible["Passport_No"].IfDefault;
            panel.Columns["AddressA"].Width = 250;
            panel.Columns["AddressA"].Visible = columns_Names_visible["AddressA"].IfDefault;
            panel.Columns["Tel"].Width = 200;
            panel.Columns["Tel"].Visible = columns_Names_visible["Tel"].IfDefault;
            panel.Columns["Note"].Width = 399;
            panel.Columns["Note"].Visible = columns_Names_visible["Note"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير الموظفــــين");
            }
            catch
            {
            }
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState == ViewState.Table)
            {
                VarGeneral.IsGeneralUsed = true;
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "EmpsRepShort";
                frm.Tag = LangArEn;
                frm.Repvalue = "EmpsRepShort";
                VarGeneral.vTitle = Text;
                frm.SqlWhere = string.Empty;
                frm.TopMost = true;
                frm.ShowDialog();
                VarGeneral.IsGeneralUsed = false;
            }
        }
        private void button_AddNewDept_Click(object sender, EventArgs e)
        {
            FrmDept frm = new FrmDept();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Dept.SelectedIndex > 0)
            {
                vList = comboBox_Dept.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Dept> listDept = new List<T_Dept>(dbc.T_Depts.Select((T_Dept item) => item).ToList());
            listDept.Insert(0, new T_Dept());
            comboBox_Dept.DataSource = null;
            comboBox_Dept.DataSource = listDept;
            comboBox_Dept.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Dept.ValueMember = "Dept_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Dept.Items.Count; i++)
                {
                    comboBox_Dept.SelectedIndex = i;
                    if (comboBox_Dept.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Dept.SelectedIndex = 0;
            }
        }
        private void button_SrchDept_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Dept_No", new ColumnDictinary("رقم الإدارة", "Department No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Dept";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Dept.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_AddNewJob_Click(object sender, EventArgs e)
        {
            FrmJob frm = new FrmJob();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Job.SelectedIndex > 0)
            {
                vList = comboBox_Job.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Job> list = new List<T_Job>(dbc.T_Jobs.Select((T_Job item) => item).ToList());
            list.Insert(0, new T_Job());
            comboBox_Job.DataSource = null;
            comboBox_Job.DataSource = list;
            comboBox_Job.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Job.ValueMember = "Job_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Job.Items.Count; i++)
                {
                    comboBox_Job.SelectedIndex = i;
                    if (comboBox_Job.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Job.SelectedIndex = 0;
            }
        }
        private void button_AddNewSection_Click(object sender, EventArgs e)
        {
            FrmSection frm = new FrmSection();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Section.SelectedIndex > 0)
            {
                vList = comboBox_Section.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Section> list = new List<T_Section>(dbc.T_Sections.Select((T_Section item) => item).ToList());
            list.Insert(0, new T_Section());
            comboBox_Section.DataSource = null;
            comboBox_Section.DataSource = list;
            comboBox_Section.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Section.ValueMember = "Section_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Section.Items.Count; i++)
                {
                    comboBox_Section.SelectedIndex = i;
                    if (comboBox_Section.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Section.SelectedIndex = 0;
            }
        }
        private void button_AddNewSponser_Click(object sender, EventArgs e)
        {
            FrmSponser frm = new FrmSponser();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Guarantor.SelectedIndex > 0)
            {
                vList = comboBox_Guarantor.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Guarantor> list = new List<T_Guarantor>(dbc.T_Guarantors.Select((T_Guarantor item) => item).ToList());
            list.Insert(0, new T_Guarantor());
            comboBox_Guarantor.DataSource = null;
            comboBox_Guarantor.DataSource = list;
            comboBox_Guarantor.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Guarantor.ValueMember = "Guarantor_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Guarantor.Items.Count; i++)
                {
                    comboBox_Guarantor.SelectedIndex = i;
                    if (comboBox_Guarantor.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Guarantor.SelectedIndex = 0;
            }
        }
        private void button_AddNewCity_Click(object sender, EventArgs e)
        {
            FrmCity frm = new FrmCity();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_CityNo.SelectedIndex > 0)
            {
                vList = comboBox_CityNo.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_City> list = new List<T_City>(dbc.T_Cities.Select((T_City item) => item).ToList());
            list.Insert(0, new T_City());
            comboBox_CityNo.DataSource = null;
            comboBox_CityNo.DataSource = list;
            comboBox_CityNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_CityNo.ValueMember = "City_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_CityNo.Items.Count; i++)
                {
                    comboBox_CityNo.SelectedIndex = i;
                    if (comboBox_CityNo.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_CityNo.SelectedIndex = 0;
            }
        }
        private void button_AddNewNation_Click(object sender, EventArgs e)
        {
            FrmNation frm = new FrmNation();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Nationalty.SelectedIndex > 0)
            {
                vList = comboBox_Nationalty.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Nationality> list = new List<T_Nationality>(dbc.T_Nationalities.Select((T_Nationality item) => item).ToList());
            list.Insert(0, new T_Nationality());
            comboBox_Nationalty.DataSource = null;
            comboBox_Nationalty.DataSource = list;
            comboBox_Nationalty.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Nationalty.ValueMember = "Nation_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Nationalty.Items.Count; i++)
                {
                    comboBox_Nationalty.SelectedIndex = i;
                    if (comboBox_Nationalty.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Nationalty.SelectedIndex = 0;
            }
        }
        private void button_AddNewReligon_Click(object sender, EventArgs e)
        {
            FrmReligions frm = new FrmReligions();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_Religion.SelectedIndex > 0)
            {
                vList = comboBox_Religion.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Religion> list = new List<T_Religion>(dbc.T_Religions.Select((T_Religion item) => item).ToList());
            list.Insert(0, new T_Religion());
            comboBox_Religion.DataSource = null;
            comboBox_Religion.DataSource = list;
            comboBox_Religion.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_Religion.ValueMember = "Religion_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_Religion.Items.Count; i++)
                {
                    comboBox_Religion.SelectedIndex = i;
                    if (comboBox_Religion.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_Religion.SelectedIndex = 0;
            }
        }
        private void button_AddNewBoss_Click(object sender, EventArgs e)
        {
            FrmBoss frm = new FrmBoss();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_DirBoss.SelectedIndex > 0)
            {
                vList = comboBox_DirBoss.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Boss> list = new List<T_Boss>(dbc.T_Bosses.Select((T_Boss item) => item).ToList());
            list.Insert(0, new T_Boss());
            comboBox_DirBoss.DataSource = null;
            comboBox_DirBoss.DataSource = list;
            comboBox_DirBoss.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_DirBoss.ValueMember = "Boss_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_DirBoss.Items.Count; i++)
                {
                    comboBox_DirBoss.SelectedIndex = i;
                    if (comboBox_DirBoss.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_DirBoss.SelectedIndex = 0;
            }
        }
        private void button_AddNewBirthPlaces_Click(object sender, EventArgs e)
        {
            FrmBirthPlace frm = new FrmBirthPlace();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_BirthPlace.SelectedIndex > 0)
            {
                vList = comboBox_BirthPlace.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_BirthPlace> list = new List<T_BirthPlace>(dbc.T_BirthPlaces.Select((T_BirthPlace item) => item).ToList());
            list.Insert(0, new T_BirthPlace());
            comboBox_BirthPlace.DataSource = null;
            comboBox_BirthPlace.DataSource = list;
            comboBox_BirthPlace.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_BirthPlace.ValueMember = "BirthPlaceNo";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_BirthPlace.Items.Count; i++)
                {
                    comboBox_BirthPlace.SelectedIndex = i;
                    if (comboBox_BirthPlace.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_BirthPlace.SelectedIndex = 0;
            }
        }
        private void button_AddNewContract_Click(object sender, EventArgs e)
        {
            FrmContract frm = new FrmContract();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_ContrTyp.SelectedIndex > 0)
            {
                vList = comboBox_ContrTyp.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Contract> list = new List<T_Contract>(dbc.T_Contracts.Select((T_Contract item) => item).ToList());
            list.Insert(0, new T_Contract());
            comboBox_ContrTyp.DataSource = null;
            comboBox_ContrTyp.DataSource = list;
            comboBox_ContrTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_ContrTyp.ValueMember = "Contract_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_ContrTyp.Items.Count; i++)
                {
                    comboBox_ContrTyp.SelectedIndex = i;
                    if (comboBox_ContrTyp.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_ContrTyp.SelectedIndex = 0;
            }
        }
        private void textBox_NameA_Leave(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        private void button_Pic_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|TIFF Files (*.tiff)|*.tiff|BMP Files (*.bmp)|*.bmp";
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        openFileDialog1.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    }
                }
                catch
                {
                }
                openFileDialog1.ShowDialog();
                string mypic_path = openFileDialog1.FileName;
                if (File.Exists(mypic_path))
                {
                    pictureBox_EnterPic.Image = Image.FromFile(mypic_path);
                    Bitmap OriginalBM = new Bitmap(pictureBox_EnterPic.Image);
                    pictureBox_EnterPic.Image = OriginalBM;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Pic_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_SrchJob_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Job_No", new ColumnDictinary("رقم الوظيفة", "Job No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Job";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Job.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchSection_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Section_No", new ColumnDictinary("رقم القسم", "Section No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Section";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Section.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchGuartor_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Guarantor_No", new ColumnDictinary("رقم الكفيل", "Guarantor No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Address", new ColumnDictinary("العنوان", "Address", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Tel", new ColumnDictinary("الهاتف", "Tel", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Fax", new ColumnDictinary("الفاكس", "Fax", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Mobil", new ColumnDictinary("جـــوال", "Mobile", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("CodPc", new ColumnDictinary("رقم الحاسب الآلي", "Computer No", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Guarantor";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Guarantor.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchNation_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Nation_No", new ColumnDictinary("رقم الجنسية", "Nationality No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("SalSubtract", new ColumnDictinary("المستقطع من الراتب", "Deducted from Salary", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("CompPaying", new ColumnDictinary("المستقطع من الشركة", "Deducted from Company", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Nationality";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Nationalty.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void checkBox_ClearPic_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                pictureBox_EnterPic.Image = null;
            }
            catch
            {
            }
        }
        private void dateTimeInput_DateAppointment_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateAppointment.SelectAll();
        }
        private void dateTimeInput_DateAppointment_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_DateAppointment.Text = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DateAppointment.Text = string.Empty;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_DateAppointment.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateAppointment.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
        }
        private void dateTimeInput_StartContr_Click(object sender, EventArgs e)
        {
            dateTimeInput_StartContr.SelectAll();
        }
        private void dateTimeInput_EndContr_Click(object sender, EventArgs e)
        {
            dateTimeInput_EndContr.SelectAll();
        }
        private void dateTimeInput_StartContr_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_StartContr.Text = Convert.ToDateTime(dateTimeInput_StartContr.Text).ToString("yyyy/MM/dd");
                try
                {
                    dateTimeInput_EndContr.Text = int.Parse(dateTimeInput_StartContr.Text.Substring(0, 4)) + 1 + dateTimeInput_StartContr.Text.Substring(4);
                }
                catch
                {
                }
            }
            catch
            {
                dateTimeInput_StartContr.Text = string.Empty;
                if (VarGeneral.CheckDate(dateTimeInput_EndContr.Text) && !VarGeneral.CheckDate(dateTimeInput_StartContr.Text))
                {
                    try
                    {
                        dateTimeInput_StartContr.Text = int.Parse(dateTimeInput_EndContr.Text.Substring(0, 4)) - 1 + dateTimeInput_EndContr.Text.Substring(4);
                    }
                    catch
                    {
                    }
                }
            }
        }
        private void dateTimeInput_EndContr_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_EndContr.Text = Convert.ToDateTime(dateTimeInput_EndContr.Text).ToString("yyyy/MM/dd");
                if (!VarGeneral.CheckDate(dateTimeInput_EndContr.Text))
                {
                    return;
                }
                if (!VarGeneral.CheckDate(dateTimeInput_StartContr.Text))
                {
                    try
                    {
                        dateTimeInput_StartContr.Text = int.Parse(dateTimeInput_EndContr.Text.Substring(0, 4)) - 1 + dateTimeInput_EndContr.Text.Substring(4);
                    }
                    catch
                    {
                    }
                }
                else if (Convert.ToDateTime(dateTimeInput_StartContr.Text) >= Convert.ToDateTime(dateTimeInput_EndContr.Text))
                {
                    dateTimeInput_EndContr.Text = string.Empty;
                }
            }
            catch
            {
                dateTimeInput_EndContr.Text = string.Empty;
            }
        }
        private void dateTimeInput_LastFilter_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_LastFilter.Text = Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_LastFilter.Text = string.Empty;
            }
        }
        private void dateTimeInput_LastFilter_Click(object sender, EventArgs e)
        {
            dateTimeInput_LastFilter.SelectAll();
        }
        private void button_SrchBoss_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Boss_No", new ColumnDictinary("رقم المدير", "Boss No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Boss";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_DirBoss.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void textBox_SocialInsuranceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void textBox_WorkNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void textBox_ID_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void dateTimeInput_ID_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_ID_Date.Text = Convert.ToDateTime(dateTimeInput_ID_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ID_Date.Text = string.Empty;
            }
        }
        private void dateTimeInput_ID_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_ID_DateEnd.Text = Convert.ToDateTime(dateTimeInput_ID_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ID_DateEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_Pass_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Pass_Date.Text = Convert.ToDateTime(dateTimeInput_Pass_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Pass_Date.Text = string.Empty;
            }
        }
        private void dateTimeInput_Passport_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Passport_DateEnd.Text = Convert.ToDateTime(dateTimeInput_Passport_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Passport_DateEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_License_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_License_Date.Text = Convert.ToDateTime(dateTimeInput_License_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_License_Date.Text = string.Empty;
            }
        }
        private void dateTimeInput_License_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_License_DateEnd.Text = Convert.ToDateTime(dateTimeInput_License_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_License_DateEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_Form_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Form_Date.Text = Convert.ToDateTime(dateTimeInput_Form_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Form_Date.Text = string.Empty;
            }
        }
        private void dateTimeInput_Form_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Form_DateEnd.Text = Convert.ToDateTime(dateTimeInput_Form_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Form_DateEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_Insurance_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Insurance_Date.Text = Convert.ToDateTime(dateTimeInput_Insurance_Date.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Insurance_Date.Text = string.Empty;
            }
        }
        private void dateTimeInput_Insurance_DateEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_Insurance_DateEnd.Text = Convert.ToDateTime(dateTimeInput_Insurance_DateEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_Insurance_DateEnd.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate.Text = Convert.ToDateTime(dateTimeInput_BirthDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate.Text = string.Empty;
            }
        }
        private void dateTimeInput_ID_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_ID_Date.SelectAll();
        }
        private void dateTimeInput_ID_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_ID_DateEnd.SelectAll();
        }
        private void dateTimeInput_Pass_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_Pass_Date.SelectAll();
        }
        private void dateTimeInput_Passport_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_Passport_DateEnd.SelectAll();
        }
        private void dateTimeInput_License_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_License_DateEnd.SelectAll();
        }
        private void dateTimeInput_License_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_License_Date.SelectAll();
        }
        private void dateTimeInput_Form_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_Form_DateEnd.SelectAll();
        }
        private void dateTimeInput_Form_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_Form_Date.SelectAll();
        }
        private void dateTimeInput_Insurance_Date_Click(object sender, EventArgs e)
        {
            dateTimeInput_Insurance_Date.SelectAll();
        }
        private void dateTimeInput_Insurance_DateEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_Insurance_DateEnd.SelectAll();
        }
        private void dateTimeInput_BirthDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate.SelectAll();
        }
        private void button_SrchID_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_ID_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchPassport_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Passport_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchInsurance_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Insurance_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchLicense_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_License_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchForms_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Form_From.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void radioButton_SatPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SatTime1.Enabled = true;
            textBox_SatTimeAllow1.Enabled = true;
            textBox_SatLeaveTime1.Enabled = true;
            textBox_SatTime2.Enabled = false;
            textBox_SatTimeAllow2.Enabled = false;
            textBox_SatLeaveTime2.Enabled = false;
        }
        private void radioButton_SatPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SatTime1.Enabled = true;
            textBox_SatTimeAllow1.Enabled = true;
            textBox_SatLeaveTime1.Enabled = true;
            textBox_SatTime2.Enabled = true;
            textBox_SatTimeAllow2.Enabled = true;
            textBox_SatLeaveTime2.Enabled = true;
        }
        private void radioButton_SatBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SatTime1.Enabled = false;
            textBox_SatTimeAllow1.Enabled = false;
            textBox_SatLeaveTime1.Enabled = false;
            textBox_SatTime2.Enabled = false;
            textBox_SatTimeAllow2.Enabled = false;
            textBox_SatLeaveTime2.Enabled = false;
        }
        private void radioButton_SunPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SunTime1.Enabled = true;
            textBox_SunTimeAllow1.Enabled = true;
            textBox_SunLeaveTime1.Enabled = true;
            textBox_SunTime2.Enabled = false;
            textBox_SunTimeAllow2.Enabled = false;
            textBox_SunLeaveTime2.Enabled = false;
        }
        private void radioButton_SunPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SunTime1.Enabled = true;
            textBox_SunTimeAllow1.Enabled = true;
            textBox_SunLeaveTime1.Enabled = true;
            textBox_SunTime2.Enabled = true;
            textBox_SunTimeAllow2.Enabled = true;
            textBox_SunLeaveTime2.Enabled = true;
        }
        private void radioButton_SunBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SunTime1.Enabled = false;
            textBox_SunTimeAllow1.Enabled = false;
            textBox_SunLeaveTime1.Enabled = false;
            textBox_SunTime2.Enabled = false;
            textBox_SunTimeAllow2.Enabled = false;
            textBox_SunLeaveTime2.Enabled = false;
        }
        private void radioButton_MonPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MonTime1.Enabled = true;
            textBox_MonTimeAllow1.Enabled = true;
            textBox_MonLeaveTime1.Enabled = true;
            textBox_MonTime2.Enabled = false;
            textBox_MonTimeAllow2.Enabled = false;
            textBox_MonLeaveTime2.Enabled = false;
        }
        private void radioButton_MonPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MonTime1.Enabled = true;
            textBox_MonTimeAllow1.Enabled = true;
            textBox_MonLeaveTime1.Enabled = true;
            textBox_MonTime2.Enabled = true;
            textBox_MonTimeAllow2.Enabled = true;
            textBox_MonLeaveTime2.Enabled = true;
        }
        private void radioButton_MonBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_MonTime1.Enabled = false;
            textBox_MonTimeAllow1.Enabled = false;
            textBox_MonLeaveTime1.Enabled = false;
            textBox_MonTime2.Enabled = false;
            textBox_MonTimeAllow2.Enabled = false;
            textBox_MonLeaveTime2.Enabled = false;
        }
        private void radioButton_TusPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_TusTime1.Enabled = true;
            textBox_TusTimeAllow1.Enabled = true;
            textBox_TusLeaveTime1.Enabled = true;
            textBox_TusTime2.Enabled = false;
            textBox_TusTimeAllow2.Enabled = false;
            textBox_TusLeaveTime2.Enabled = false;
        }
        private void radioButton_TusPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_TusTime1.Enabled = true;
            textBox_TusTimeAllow1.Enabled = true;
            textBox_TusLeaveTime1.Enabled = true;
            textBox_TusTime2.Enabled = true;
            textBox_TusTimeAllow2.Enabled = true;
            textBox_TusLeaveTime2.Enabled = true;
        }
        private void radioButton_TusBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_TusTime1.Enabled = false;
            textBox_TusTimeAllow1.Enabled = false;
            textBox_TusLeaveTime1.Enabled = false;
            textBox_TusTime2.Enabled = false;
            textBox_TusTimeAllow2.Enabled = false;
            textBox_TusLeaveTime2.Enabled = false;
        }
        private void radioButton_FriPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_FriTime1.Enabled = true;
            textBox_FriTimeAllow1.Enabled = true;
            textBox_LeaveTime1.Enabled = true;
            textBox_FriTime2.Enabled = false;
            textBox_FriTimeAllow2.Enabled = false;
            textBox_LeaveTime2.Enabled = false;
        }
        private void radioButton_FriPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_FriTime1.Enabled = true;
            textBox_FriTimeAllow1.Enabled = true;
            textBox_LeaveTime1.Enabled = true;
            textBox_FriTime2.Enabled = true;
            textBox_FriTimeAllow2.Enabled = true;
            textBox_LeaveTime2.Enabled = true;
        }
        private void radioButton_FriBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_FriTime1.Enabled = false;
            textBox_FriTimeAllow1.Enabled = false;
            textBox_LeaveTime1.Enabled = false;
            textBox_FriTime2.Enabled = false;
            textBox_FriTimeAllow2.Enabled = false;
            textBox_LeaveTime2.Enabled = false;
        }
        private void radioButton_ThurPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ThurTime1.Enabled = true;
            textBox_ThurTimeAllow1.Enabled = true;
            textBox_ThurLeaveTime1.Enabled = true;
            textBox_ThurTime2.Enabled = false;
            textBox_ThurTimeAllow2.Enabled = false;
            textBox_ThurLeaveTime2.Enabled = false;
        }
        private void radioButton_ThurPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ThurTime1.Enabled = true;
            textBox_ThurTimeAllow1.Enabled = true;
            textBox_ThurLeaveTime1.Enabled = true;
            textBox_ThurTime2.Enabled = true;
            textBox_ThurTimeAllow2.Enabled = true;
            textBox_ThurLeaveTime2.Enabled = true;
        }
        private void radioButton_ThurBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_ThurTime1.Enabled = false;
            textBox_ThurTimeAllow1.Enabled = false;
            textBox_ThurLeaveTime1.Enabled = false;
            textBox_ThurTime2.Enabled = false;
            textBox_ThurTimeAllow2.Enabled = false;
            textBox_ThurLeaveTime2.Enabled = false;
        }
        private void radioButton_WenPeriods1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_WenTime1.Enabled = true;
            textBox_WenTimeAllow1.Enabled = true;
            textBox_WenLeaveTime1.Enabled = true;
            textBox_WenTime2.Enabled = false;
            textBox_WenTimeAllow2.Enabled = false;
            textBox_WenLeaveTime2.Enabled = false;
        }
        private void radioButton_WenPeriods2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_WenTime1.Enabled = true;
            textBox_WenTimeAllow1.Enabled = true;
            textBox_WenLeaveTime1.Enabled = true;
            textBox_WenTime2.Enabled = true;
            textBox_WenTimeAllow2.Enabled = true;
            textBox_WenLeaveTime2.Enabled = true;
        }
        private void radioButton_WenBreakDay_CheckedChanged(object sender, EventArgs e)
        {
            textBox_WenTime1.Enabled = false;
            textBox_WenTimeAllow1.Enabled = false;
            textBox_WenLeaveTime1.Enabled = false;
            textBox_WenTime2.Enabled = false;
            textBox_WenTimeAllow2.Enabled = false;
            textBox_WenLeaveTime2.Enabled = false;
        }
        private void textBox_SatTime1_Click(object sender, EventArgs e)
        {
            textBox_SatTime1.SelectAll();
        }
        private void textBox_SatTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_SatTimeAllow1.SelectAll();
        }
        private void textBox_SatLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_SatLeaveTime1.SelectAll();
        }
        private void textBox_SatTime2_Click(object sender, EventArgs e)
        {
            textBox_SatTime2.SelectAll();
        }
        private void textBox_SatTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_SatTimeAllow2.SelectAll();
        }
        private void textBox_SatLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_SatLeaveTime2.SelectAll();
        }
        private void textBox_SunTime1_Click(object sender, EventArgs e)
        {
            textBox_SunTime1.SelectAll();
        }
        private void textBox_SunTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_SunTimeAllow1.SelectAll();
        }
        private void textBox_SunLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_SunLeaveTime1.SelectAll();
        }
        private void textBox_SunTime2_Click(object sender, EventArgs e)
        {
            textBox_SunTime2.SelectAll();
        }
        private void textBox_SunTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_SunTimeAllow2.SelectAll();
        }
        private void textBox_SunLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_SunLeaveTime2.SelectAll();
        }
        private void textBox_MonTime1_Click(object sender, EventArgs e)
        {
            textBox_MonTime1.SelectAll();
        }
        private void textBox_MonTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_MonTimeAllow1.SelectAll();
        }
        private void textBox_MonLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_MonLeaveTime1.SelectAll();
        }
        private void textBox_MonTime2_Click(object sender, EventArgs e)
        {
            textBox_MonTime2.SelectAll();
        }
        private void textBox_MonTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_MonTimeAllow2.SelectAll();
        }
        private void textBox_MonLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_MonLeaveTime2.SelectAll();
        }
        private void textBox_TusTime1_Click(object sender, EventArgs e)
        {
            textBox_TusTime1.SelectAll();
        }
        private void textBox_TusTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_TusTimeAllow1.SelectAll();
        }
        private void textBox_TusLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_TusLeaveTime1.SelectAll();
        }
        private void textBox_TusTime2_Click(object sender, EventArgs e)
        {
            textBox_TusTime2.SelectAll();
        }
        private void textBox_TusTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_TusTimeAllow2.SelectAll();
        }
        private void textBox_TusLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_TusLeaveTime2.SelectAll();
        }
        private void textBox_WenTime1_Click(object sender, EventArgs e)
        {
            textBox_WenTime1.SelectAll();
        }
        private void textBox_WenTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_WenTimeAllow1.SelectAll();
        }
        private void textBox_WenLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_WenLeaveTime1.SelectAll();
        }
        private void textBox_WenTime2_Click(object sender, EventArgs e)
        {
            textBox_WenTime2.SelectAll();
        }
        private void textBox_WenTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_WenTimeAllow2.SelectAll();
        }
        private void textBox_WenLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_WenLeaveTime2.SelectAll();
        }
        private void textBox_ThurTime1_Click(object sender, EventArgs e)
        {
            textBox_ThurTime1.SelectAll();
        }
        private void textBox_ThurTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_ThurTimeAllow1.SelectAll();
        }
        private void textBox_ThurLeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_ThurLeaveTime1.SelectAll();
        }
        private void textBox_ThurTime2_Click(object sender, EventArgs e)
        {
            textBox_ThurTime2.SelectAll();
        }
        private void textBox_ThurTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_ThurTimeAllow2.SelectAll();
        }
        private void textBox_ThurLeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_ThurLeaveTime2.SelectAll();
        }
        private void textBox_FriTime2_Click(object sender, EventArgs e)
        {
            textBox_FriTime2.SelectAll();
        }
        private void textBox_FriTime1_Click(object sender, EventArgs e)
        {
            textBox_FriTime1.SelectAll();
        }
        private void textBox_FriTimeAllow1_Click(object sender, EventArgs e)
        {
            textBox_FriTimeAllow1.SelectAll();
        }
        private void textBox_FriTimeAllow2_Click(object sender, EventArgs e)
        {
            textBox_FriTimeAllow2.SelectAll();
        }
        private void textBox_LeaveTime1_Click(object sender, EventArgs e)
        {
            textBox_LeaveTime1.SelectAll();
        }
        private void textBox_LeaveTime2_Click(object sender, EventArgs e)
        {
            textBox_LeaveTime2.SelectAll();
        }
        private void textBox_SatTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatTime1.Text))
            {
                textBox_SatTime1.Text = TimeSpan.Parse(textBox_SatTime1.Text).ToString();
            }
            else
            {
                textBox_SatTime1.Text = string.Empty;
            }
        }
        private void textBox_SatTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatTimeAllow1.Text))
            {
                textBox_SatTimeAllow1.Text = TimeSpan.Parse(textBox_SatTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_SatTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_SatLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatLeaveTime1.Text))
            {
                textBox_SatLeaveTime1.Text = TimeSpan.Parse(textBox_SatLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_SatLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_SatTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatTime2.Text))
            {
                textBox_SatTime2.Text = TimeSpan.Parse(textBox_SatTime2.Text).ToString();
            }
            else
            {
                textBox_SatTime2.Text = string.Empty;
            }
        }
        private void textBox_SatTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatTimeAllow2.Text))
            {
                textBox_SatTimeAllow2.Text = TimeSpan.Parse(textBox_SatTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_SatTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_SatLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SatLeaveTime2.Text))
            {
                textBox_SatLeaveTime2.Text = TimeSpan.Parse(textBox_SatLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_SatLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_SunTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunTime1.Text))
            {
                textBox_SunTime1.Text = TimeSpan.Parse(textBox_SunTime1.Text).ToString();
            }
            else
            {
                textBox_SunTime1.Text = string.Empty;
            }
        }
        private void textBox_SunTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunTimeAllow1.Text))
            {
                textBox_SunTimeAllow1.Text = TimeSpan.Parse(textBox_SunTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_SunTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_SunLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunLeaveTime1.Text))
            {
                textBox_SunLeaveTime1.Text = TimeSpan.Parse(textBox_SunLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_SunLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_SunTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunTime2.Text))
            {
                textBox_SunTime2.Text = TimeSpan.Parse(textBox_SunTime2.Text).ToString();
            }
            else
            {
                textBox_SunTime2.Text = string.Empty;
            }
        }
        private void textBox_SunTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunTimeAllow2.Text))
            {
                textBox_SunTimeAllow2.Text = TimeSpan.Parse(textBox_SunTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_SunTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_SunLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_SunLeaveTime2.Text))
            {
                textBox_SunLeaveTime2.Text = TimeSpan.Parse(textBox_SunLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_SunLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_MonTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonTime1.Text))
            {
                textBox_MonTime1.Text = TimeSpan.Parse(textBox_MonTime1.Text).ToString();
            }
            else
            {
                textBox_MonTime1.Text = string.Empty;
            }
        }
        private void textBox_MonTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonTimeAllow1.Text))
            {
                textBox_MonTimeAllow1.Text = TimeSpan.Parse(textBox_MonTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_MonTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_MonLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonLeaveTime1.Text))
            {
                textBox_MonLeaveTime1.Text = TimeSpan.Parse(textBox_MonLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_MonLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_MonTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonTime2.Text))
            {
                textBox_MonTime2.Text = TimeSpan.Parse(textBox_MonTime2.Text).ToString();
            }
            else
            {
                textBox_MonTime2.Text = string.Empty;
            }
        }
        private void textBox_MonTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonTimeAllow2.Text))
            {
                textBox_MonTimeAllow2.Text = TimeSpan.Parse(textBox_MonTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_MonTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_MonLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_MonLeaveTime2.Text))
            {
                textBox_MonLeaveTime2.Text = TimeSpan.Parse(textBox_MonLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_MonLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_TusTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusTime1.Text))
            {
                textBox_TusTime1.Text = TimeSpan.Parse(textBox_TusTime1.Text).ToString();
            }
            else
            {
                textBox_TusTime1.Text = string.Empty;
            }
        }
        private void textBox_TusTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusTimeAllow1.Text))
            {
                textBox_TusTimeAllow1.Text = TimeSpan.Parse(textBox_TusTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_TusTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_TusLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusLeaveTime1.Text))
            {
                textBox_TusLeaveTime1.Text = TimeSpan.Parse(textBox_TusLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_TusLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_TusTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusTime2.Text))
            {
                textBox_TusTime2.Text = TimeSpan.Parse(textBox_TusTime2.Text).ToString();
            }
            else
            {
                textBox_TusTime2.Text = string.Empty;
            }
        }
        private void textBox_TusTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusTimeAllow2.Text))
            {
                textBox_TusTimeAllow2.Text = TimeSpan.Parse(textBox_TusTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_TusTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_TusLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_TusLeaveTime2.Text))
            {
                textBox_TusLeaveTime2.Text = TimeSpan.Parse(textBox_TusLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_TusLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_WenTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenTime1.Text))
            {
                textBox_WenTime1.Text = TimeSpan.Parse(textBox_WenTime1.Text).ToString();
            }
            else
            {
                textBox_WenTime1.Text = string.Empty;
            }
        }
        private void textBox_WenTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenTimeAllow1.Text))
            {
                textBox_WenTimeAllow1.Text = TimeSpan.Parse(textBox_WenTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_WenTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_WenLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenLeaveTime1.Text))
            {
                textBox_WenLeaveTime1.Text = TimeSpan.Parse(textBox_WenLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_WenLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_WenTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenTime2.Text))
            {
                textBox_WenTime2.Text = TimeSpan.Parse(textBox_WenTime2.Text).ToString();
            }
            else
            {
                textBox_WenTime2.Text = string.Empty;
            }
        }
        private void textBox_WenTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenTimeAllow2.Text))
            {
                textBox_WenTimeAllow2.Text = TimeSpan.Parse(textBox_WenTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_WenTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_WenLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_WenLeaveTime2.Text))
            {
                textBox_WenLeaveTime2.Text = TimeSpan.Parse(textBox_WenLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_WenLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_ThurTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurTime1.Text))
            {
                textBox_ThurTime1.Text = TimeSpan.Parse(textBox_ThurTime1.Text).ToString();
            }
            else
            {
                textBox_ThurTime1.Text = string.Empty;
            }
        }
        private void textBox_ThurTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurTimeAllow1.Text))
            {
                textBox_ThurTimeAllow1.Text = TimeSpan.Parse(textBox_ThurTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_ThurTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_ThurLeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurLeaveTime1.Text))
            {
                textBox_ThurLeaveTime1.Text = TimeSpan.Parse(textBox_ThurLeaveTime1.Text).ToString();
            }
            else
            {
                textBox_ThurLeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_ThurTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurTime2.Text))
            {
                textBox_ThurTime2.Text = TimeSpan.Parse(textBox_ThurTime2.Text).ToString();
            }
            else
            {
                textBox_ThurTime2.Text = string.Empty;
            }
        }
        private void textBox_ThurTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurTimeAllow2.Text))
            {
                textBox_ThurTimeAllow2.Text = TimeSpan.Parse(textBox_ThurTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_ThurTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_ThurLeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_ThurLeaveTime2.Text))
            {
                textBox_ThurLeaveTime2.Text = TimeSpan.Parse(textBox_ThurLeaveTime2.Text).ToString();
            }
            else
            {
                textBox_ThurLeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_FriTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_FriTime1.Text))
            {
                textBox_FriTime1.Text = TimeSpan.Parse(textBox_FriTime1.Text).ToString();
            }
            else
            {
                textBox_FriTime1.Text = string.Empty;
            }
        }
        private void textBox_FriTimeAllow1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_FriTimeAllow1.Text))
            {
                textBox_FriTimeAllow1.Text = TimeSpan.Parse(textBox_FriTimeAllow1.Text).ToString();
            }
            else
            {
                textBox_FriTimeAllow1.Text = string.Empty;
            }
        }
        private void textBox_LeaveTime1_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_LeaveTime1.Text))
            {
                textBox_LeaveTime1.Text = TimeSpan.Parse(textBox_LeaveTime1.Text).ToString();
            }
            else
            {
                textBox_LeaveTime1.Text = string.Empty;
            }
        }
        private void textBox_FriTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_FriTime2.Text))
            {
                textBox_FriTime2.Text = TimeSpan.Parse(textBox_FriTime2.Text).ToString();
            }
            else
            {
                textBox_FriTime2.Text = string.Empty;
            }
        }
        private void textBox_FriTimeAllow2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_FriTimeAllow2.Text))
            {
                textBox_FriTimeAllow2.Text = TimeSpan.Parse(textBox_FriTimeAllow2.Text).ToString();
            }
            else
            {
                textBox_FriTimeAllow2.Text = string.Empty;
            }
        }
        private void textBox_LeaveTime2_Leave(object sender, EventArgs e)
        {
            if (VarGeneral.CheckTime(textBox_LeaveTime2.Text))
            {
                textBox_LeaveTime2.Text = TimeSpan.Parse(textBox_LeaveTime2.Text).ToString();
            }
            else
            {
                textBox_LeaveTime2.Text = string.Empty;
            }
        }
        private void textBox_SatTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_SatTimeAllow1.Text = textBox_SatTime1.Text;
            }
        }
        private void textBox_SatTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_SatTimeAllow2.Text = textBox_SatTime2.Text;
            }
        }
        private void textBox_SunTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_SunTimeAllow1.Text = textBox_SunTime1.Text;
            }
        }
        private void textBox_SunTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_SunTimeAllow2.Text = textBox_SunTime2.Text;
            }
        }
        private void textBox_MonTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_MonTimeAllow1.Text = textBox_MonTime1.Text;
            }
        }
        private void textBox_MonTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_MonTimeAllow2.Text = textBox_MonTime2.Text;
            }
        }
        private void textBox_TusTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_TusTimeAllow1.Text = textBox_TusTime1.Text;
            }
        }
        private void textBox_TusTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_TusTimeAllow2.Text = textBox_TusTime2.Text;
            }
        }
        private void textBox_WenTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_WenTimeAllow1.Text = textBox_WenTime1.Text;
            }
        }
        private void textBox_WenTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_WenTimeAllow2.Text = textBox_WenTime2.Text;
            }
        }
        private void textBox_ThurTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_ThurTimeAllow1.Text = textBox_ThurTime1.Text;
            }
        }
        private void textBox_ThurTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_ThurTimeAllow2.Text = textBox_ThurTime2.Text;
            }
        }
        private void textBox_FriTime1_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_FriTimeAllow1.Text = textBox_FriTime1.Text;
            }
        }
        private void textBox_FriTime2_TextChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                textBox_FriTimeAllow2.Text = textBox_FriTime2.Text;
            }
        }
        private void dateTimeInput_VisaDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_VisaDate.SelectAll();
        }
        private void dateTimeInput_VisaDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_VisaDate.Text = Convert.ToDateTime(dateTimeInput_VisaDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_VisaDate.Text = string.Empty;
            }
        }
        private void comboBox_InsuranceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_InsuranceType.SelectedIndex > 0)
            {
                textBox_Insurance_Class.Enabled = true;
            }
            else
            {
                textBox_Insurance_Class.Enabled = false;
            }
        }
        private void button_InsuranceType_Click(object sender, EventArgs e)
        {
            FrmInsuranceHealth frm = new FrmInsuranceHealth();
            frm.Tag = LangArEn;
            string vList = string.Empty;
            if (comboBox_InsuranceType.SelectedIndex > 0)
            {
                vList = comboBox_InsuranceType.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_Insurance> listGur = new List<T_Insurance>(dbc.T_Insurances.Select((T_Insurance item) => item).ToList());
            listGur.Insert(0, new T_Insurance());
            comboBox_InsuranceType.DataSource = null;
            listGur.Insert(0, new T_Insurance());
            comboBox_InsuranceType.DataSource = listGur;
            comboBox_InsuranceType.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_InsuranceType.ValueMember = "Insurance_No";
            if (vList != string.Empty)
            {
                for (int i = 0; i < comboBox_InsuranceType.Items.Count; i++)
                {
                    comboBox_InsuranceType.SelectedIndex = i;
                    if (comboBox_InsuranceType.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_InsuranceType.SelectedIndex = 0;
            }
        }
        private void bubbleButton_InsuranceType_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Insurance_No", new ColumnDictinary("الرقم", "Job No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Insurance";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_InsuranceType.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void buttonX_OpenFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (Button_Save.Enabled || string.IsNullOrEmpty(data_this.Emp_No))
                {
                    return;
                }
                int b = 0;
                string ServiceNm = string.Empty;
                for (b = 0; b < VarGeneral.gServerName.Length && !(VarGeneral.gServerName.Substring(b, 1) == "\\"); b++)
                {
                }
                try
                {
                    ServiceNm = VarGeneral.gServerName.Substring(b + 1);
                }
                catch
                {
                    ServiceNm = string.Empty;
                }
                if (string.IsNullOrEmpty(ServiceNm))
                {
                    ServiceNm = VarGeneral.DBNo.Replace("DBPROSOFT_", null);
                }
                try
                {
                    if (!Directory.Exists((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm))
                    {
                        Directory.CreateDirectory((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm);
                    }
                }
                catch
                {
                }
                try
                {
                    if (!Directory.Exists((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber))
                    {
                        Directory.CreateDirectory((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber);
                    }
                }
                catch
                {
                }
                string filename = string.Empty;
                try
                {
                    if (!Directory.Exists((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments"))
                    {
                        Directory.CreateDirectory((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments");
                    }
                }
                catch
                {
                }
           System.Windows.Forms. OpenFileDialog  ofd = new System.Windows.Forms. OpenFileDialog (); 
                ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|TIFF Files (*.tiff)|*.tiff|BMP Files (*.bmp)|*.bmp";
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        ofd.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                    }
                }
                catch
                {
                }
                ofd.ShowDialog();
                filename = ofd.FileName;
                if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
                {
                    return;
                }
                string FileNm = "00001";
                if (listBox_ImageFiles2.Items.Count > 0)
                {
                    FileNm = listBox_ImageFiles2.Items[listBox_ImageFiles2.Items.Count - 1].ToString();
                    FileNm = (int.Parse(FileNm) + 1).ToString();
                    while (FileNm.Length < 5)
                    {
                        FileNm = "0" + FileNm;
                    }
                }
                string pType = string.Empty;
                for (int iicnt = 0; iicnt < filename.Length; iicnt++)
                {
                    try
                    {
                        if (filename.Substring(iicnt, 1) == ".")
                        {
                            pType = filename.Substring(iicnt);
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
                string strTmpFile = string.Empty;
                strTmpFile = ((!string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath)) ? (VarGeneral.Settings_Sys.DocumentPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments\\" + data_this.Emp_No + "-" + FileNm.Trim() + pType) : (Application.StartupPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments\\" + data_this.Emp_No + "-" + FileNm.Trim() + pType));
                File.Copy(filename, strTmpFile, overwrite: true);
                FillImageList2();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonX_OpenFiles_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonX_BrowserScannerFiles_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(data_this.Emp_No))
                {
                    FrmScannerFiles frm = new FrmScannerFiles(data_this.Emp_No, (LangArEn == 0) ? data_this.NameA : data_this.NameE);
                    frm.Tag = LangArEn;
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
            }
            catch
            {
            }
        }
        private void linkLabel_ChangeEmpNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            string vNewNo = InputDialog.mostrar((LangArEn == 0) ? "أدخل رقم الموظف الجديد : " : "Insert New Employee No : ", (LangArEn == 0) ? "تعديل رقم الموظف" : "Employee No Edite");
            if (string.IsNullOrEmpty(vNewNo))
            {
                return;
            }
            try
            {
                List<T_Emp> q = db.T_Emps.Where((T_Emp t) => t.Emp_No == vNewNo).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم الموظف مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return;
                }
                textBox_ID.TextChanged -= textBox_ID_TextChanged;
                textBox_ID.Text = vNewNo;
                State = FormState.Edit;
                Button_Save.Enabled = true;
                Button_Save_Click(sender, e);
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
            catch (Exception error)
            {
                textBox_ID.TextChanged += textBox_ID_TextChanged;
                VarGeneral.DebLog.writeLog("linkLabel_ChangeEmpNo_LinkClicked:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "حصل خطأ ما .. لم يتم عملية التعديل بنجاح" : "Error .. Editing is not Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                MessageBox.Show(error.Message);
            }
        }
        private void button_SrchSalAcc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_AccSal.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    textBox_AccSalName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    textBox_AccSalName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                textBox_AccSal.Text = string.Empty;
                textBox_AccSalName.Text = string.Empty;
            }
        }
        private void button_SrchHousAcc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_AccHousing.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    textBox_AccHousingName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    textBox_AccHousingName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                textBox_AccHousing.Text = string.Empty;
                textBox_AccHousingName.Text = string.Empty;
            }
        }
        private void button_SrchAdvancAcc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_AccLoan.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    textBox_AccLoanName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    textBox_AccLoanName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                textBox_AccLoan.Text = string.Empty;
                textBox_AccLoanName.Text = string.Empty;
            }
        }
        private void button_SrchCostCenterAcc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Cst_No", new ColumnDictinary("الرقم", "No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_CostCenter.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    textBox_CostCenterName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    textBox_CostCenterName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                textBox_CostCenter.Text = string.Empty;
                textBox_CostCenterName.Text = string.Empty;
            }
        }
        private void button_SrchBXBankNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            FrmSearch frm;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if (!switchButton_AccType.Value)
            {
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
                columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_AccDef2";
                VarGeneral.AccTyp = 2;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txtBXBankName.Text = _AccDef.Arb_Des.ToString();
                    }
                    else
                    {
                        txtBXBankName.Text = _AccDef.Eng_Des.ToString();
                    }
                }
                else
                {
                    txtBXBankNo.Text = string.Empty;
                    txtBXBankName.Text = string.Empty;
                }
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            frm = new FrmSearch();
            frm.Tag = LangArEn;
            animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 3;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtBXBankNo.Text = _AccDef.AccDef_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtBXBankName.Text = _AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtBXBankName.Text = _AccDef.Eng_Des.ToString();
                }
            }
            else
            {
                txtBXBankNo.Text = string.Empty;
                txtBXBankName.Text = string.Empty;
            }
        }
        private void buttonItem_EmpOut_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonItem_EmpOut.Checked)
            {
                if (!ContinueIfEditOrNew())
                {
                    buttonItem_EmpOut.CheckedChanged -= buttonItem_EmpOut_CheckedChanged;
                    buttonItem_EmpOut.Checked = false;
                    buttonItem_EmpOut.CheckedChanged += buttonItem_EmpOut_CheckedChanged;
                    return;
                }
                VarGeneral.FrmEmpStat = false;
                Button_Save.Visible = false;
                buttonItem_Back.Visible = true;
                buttonItem_EmpOut.Text = ((LangArEn == 0) ? "    العاملـين" : "     Emp On");
            }
            else
            {
                VarGeneral.FrmEmpStat = true;
                Button_Save.Visible = true;
                buttonItem_Back.Visible = false;
                buttonItem_EmpOut.Text = ((LangArEn == 0) ? "    المفصولين" : "     Emp Off");
            }
            vMain();
        }
        private void buttonItem_Back_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_ID.Text) && !string.IsNullOrEmpty(data_this.Emp_ID) && MessageBox.Show("سيتم تغيير حالة الموظف من المفصولين الى العاملين .. هل تريد المتبابعة ؟", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data_this.EmpState = true;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.Emp_No ?? string.Empty) + 1);
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
            }
        }
        private void buttonItem_EmpOut_Click(object sender, EventArgs e)
        {
        }
        private void textBox_VisaEnterNo_Click(object sender, EventArgs e)
        {
            textBox_VisaEnterNo.SelectAll();
        }
        private void textBox_VisaNo_Click(object sender, EventArgs e)
        {
            textBox_VisaNo.SelectAll();
        }
        private void textBox_VisaCountry_Click(object sender, EventArgs e)
        {
            textBox_VisaCountry.SelectAll();
        }
        private void button_SaveFamily_Click(object sender, EventArgs e)
        {
            if (Button_Save.Enabled || string.IsNullOrEmpty(data_this.Emp_No) || buttonItem_EmpOut.Checked)
            {
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text))
                {
                    return;
                }
                if (!buttonItem_EmpOut.Checked)
                {
                    if (db.CheckEmp_Family(textBox_ID.Tag.ToString()))
                    {
                        db.T_Families.DeleteAllOnSubmit(data_this.T_Families);
                        db.SubmitChanges();
                        dbInstance = null;
                    }
                    for (int i = 1; i <= 15; i++)
                    {
                        DataThisFamily = new T_Family();
                        if (i == 1 && !string.IsNullOrEmpty(textBox_Name1.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name1.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation1.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo1.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd1.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd1.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate1.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate1.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 2 && !string.IsNullOrEmpty(textBox_Name2.Text) && !string.IsNullOrEmpty(textBox_Name1.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name2.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation2.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo2.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd2.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd2.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate2.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate2.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 3 && !string.IsNullOrEmpty(textBox_Name3.Text) && !string.IsNullOrEmpty(textBox_Name2.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name3.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation3.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo3.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd3.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd3.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate3.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate3.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 4 && !string.IsNullOrEmpty(textBox_Name4.Text) && !string.IsNullOrEmpty(textBox_Name3.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name4.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation4.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo4.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd4.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd4.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate4.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate4.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 5 && !string.IsNullOrEmpty(textBox_Name5.Text) && !string.IsNullOrEmpty(textBox_Name4.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name5.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation5.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo5.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd5.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd5.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate5.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate5.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 6 && !string.IsNullOrEmpty(textBox_Name6.Text) && !string.IsNullOrEmpty(textBox_Name5.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name6.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation6.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo6.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd6.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate6.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate6.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 7 && !string.IsNullOrEmpty(textBox_Name7.Text) && !string.IsNullOrEmpty(textBox_Name6.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name7.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation7.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo7.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd6.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate7.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate7.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 8 && !string.IsNullOrEmpty(textBox_Name8.Text) && !string.IsNullOrEmpty(textBox_Name7.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name8.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation8.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo8.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd6.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate8.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate8.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 9 && !string.IsNullOrEmpty(textBox_Name9.Text) && !string.IsNullOrEmpty(textBox_Name8.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name9.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation9.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo9.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd9.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd9.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate9.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate9.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 10 && !string.IsNullOrEmpty(textBox_Name10.Text) && !string.IsNullOrEmpty(textBox_Name9.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name10.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation10.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo10.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd10.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd10.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate10.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate10.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 11 && !string.IsNullOrEmpty(textBox_Name11.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name11.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation11.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo11.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd11.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd11.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate11.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate11.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 12 && !string.IsNullOrEmpty(textBox_Name12.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name12.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation12.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo12.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd12.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd12.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate12.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate12.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 13 && !string.IsNullOrEmpty(textBox_Name13.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name13.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation13.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo13.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd13.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd13.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate13.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate13.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 14 && !string.IsNullOrEmpty(textBox_Name14.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name14.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation14.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo14.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd14.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd14.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate14.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate14.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                        if (i == 15 && !string.IsNullOrEmpty(textBox_Name15.Text))
                        {
                            Guid id = Guid.NewGuid();
                            DataThisFamily.Family_ID = id.ToString();
                            try
                            {
                                DataThisFamily.EmpID = textBox_ID.Tag.ToString();
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Person_No = db.MaxFamilyNo;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Name = textBox_Name15.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.Link = textBox_Relation15.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassNo = textBox_PassporntNo15.Text;
                            }
                            catch
                            {
                            }
                            try
                            {
                                DataThisFamily.PassEnd = Convert.ToDateTime(dateTimeInput_PassportDateEnd15.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_PassportDateEnd15.Text = string.Empty;
                                DataThisFamily.PassEnd = string.Empty;
                            }
                            try
                            {
                                DataThisFamily.BirthDay = Convert.ToDateTime(dateTimeInput_BirthDate15.Text).ToString("yyyy/MM/dd");
                            }
                            catch
                            {
                                dateTimeInput_BirthDate15.Text = string.Empty;
                                DataThisFamily.BirthDay = string.Empty;
                            }
                            db.T_Families.InsertOnSubmit(DataThisFamily);
                            db.SubmitChanges();
                        }
                    }
                    textBox_ID_TextChanged(sender, e);
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن تحديث بيانات موظف موقوف .. الرجاء استرجاع الموظف اولا !" : "The Employee is Suspended", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_Insurance_Class_Click(object sender, EventArgs e)
        {
            textBox_Insurance_Class.SelectAll();
        }
        private void dateTimeInput_BirthDate1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate1.Text = Convert.ToDateTime(dateTimeInput_BirthDate1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate1.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate2_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate2.Text = Convert.ToDateTime(dateTimeInput_BirthDate2.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate2.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate3_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate3.Text = Convert.ToDateTime(dateTimeInput_BirthDate3.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate3.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate4_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate4.Text = Convert.ToDateTime(dateTimeInput_BirthDate4.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate4.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate5_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate5.Text = Convert.ToDateTime(dateTimeInput_BirthDate5.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate5.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate6_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate6.Text = Convert.ToDateTime(dateTimeInput_BirthDate6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate6.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate7_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate7.Text = Convert.ToDateTime(dateTimeInput_BirthDate7.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate7.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate8_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate8.Text = Convert.ToDateTime(dateTimeInput_BirthDate8.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate8.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate9_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate9.Text = Convert.ToDateTime(dateTimeInput_BirthDate9.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate9.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate10_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate10.Text = Convert.ToDateTime(dateTimeInput_BirthDate10.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate10.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate11_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate11.Text = Convert.ToDateTime(dateTimeInput_BirthDate11.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate11.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate12_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate12.Text = Convert.ToDateTime(dateTimeInput_BirthDate12.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate12.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate13_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate13.Text = Convert.ToDateTime(dateTimeInput_BirthDate13.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate13.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate14_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate14.Text = Convert.ToDateTime(dateTimeInput_BirthDate14.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate14.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate15_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_BirthDate15.Text = Convert.ToDateTime(dateTimeInput_BirthDate15.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_BirthDate15.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd1_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd1.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd1.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd1.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd2_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd2.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd2.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd2.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd3_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd3.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd3.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd3.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd4_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd4.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd4.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd4.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd5_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd5.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd5.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd5.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd6_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd6.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd7_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd6.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd8_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd6.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd6.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd6.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd9_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd9.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd9.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd9.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd10_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd10.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd10.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd10.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd11_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd11.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd11.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd11.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd12_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd12.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd12.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd12.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd13_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd13.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd13.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd13.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd14_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd14.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd14.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd14.Text = string.Empty;
            }
        }
        private void dateTimeInput_PassportDateEnd15_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_PassportDateEnd15.Text = Convert.ToDateTime(dateTimeInput_PassportDateEnd15.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PassportDateEnd15.Text = string.Empty;
            }
        }
        private void dateTimeInput_BirthDate1_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate1.SelectAll();
        }
        private void dateTimeInput_BirthDate2_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate2.SelectAll();
        }
        private void dateTimeInput_BirthDate3_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate3.SelectAll();
        }
        private void dateTimeInput_BirthDate4_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate4.SelectAll();
        }
        private void dateTimeInput_BirthDate5_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate5.SelectAll();
        }
        private void dateTimeInput_BirthDate6_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate6.SelectAll();
        }
        private void dateTimeInput_BirthDate7_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate7.SelectAll();
        }
        private void dateTimeInput_BirthDate8_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate8.SelectAll();
        }
        private void dateTimeInput_BirthDate9_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate9.SelectAll();
        }
        private void dateTimeInput_BirthDate10_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate10.SelectAll();
        }
        private void dateTimeInput_BirthDate11_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate11.SelectAll();
        }
        private void dateTimeInput_BirthDate12_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate12.SelectAll();
        }
        private void dateTimeInput_BirthDate13_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate13.SelectAll();
        }
        private void dateTimeInput_BirthDate14_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate14.SelectAll();
        }
        private void dateTimeInput_BirthDate15_Click(object sender, EventArgs e)
        {
            dateTimeInput_BirthDate15.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd15_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd15.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd14_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd14.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd13_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd13.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd12_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd12.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd11_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd11.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd10_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd10.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd9_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd9.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd8_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd8.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd7_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd7.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd6_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd6.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd5_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd5.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd4_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd4.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd3_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd3.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd2_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd2.SelectAll();
        }
        private void dateTimeInput_PassportDateEnd1_Click(object sender, EventArgs e)
        {
            dateTimeInput_PassportDateEnd1.SelectAll();
        }
        private void textBox_PassporntNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void button_PhotoShoot_Click(object sender, EventArgs e)
        {
        }
        private void textBox_Name2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name1.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name2.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name3.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name4.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name5.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name6.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name7.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name8.Text))
            {
                e.Handled = true;
            }
        }
        private void textBox_Name10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Name9.Text))
            {
                e.Handled = true;
            }
        }
        private void button_SrchReligion_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("Religion_No", new ColumnDictinary("رقم الديانة", "Religion No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_Religion";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_Religion.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchBirthPlaces_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("BirthPlaceNo", new ColumnDictinary("الرقم", "No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "BirthPlaceNo";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_BirthPlace.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void button_SrchCities_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                Dir_ButSearch.Add("City_No", new ColumnDictinary("رقم المدينة", "City No", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, string.Empty));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
                }
                VarGeneral.SFrmTyp = "T_City";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != string.Empty)
                {
                    comboBox_CityNo.SelectedValue = int.Parse(frm.SerachNo);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void textBox_SocialInsuranceNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_SocialInsuranceNo.Text))
            {
                textBox_SocialInsuranceNo.ButtonCustom.Visible = false;
            }
            else
            {
                textBox_SocialInsuranceNo.ButtonCustom.Visible = true;
            }
        }
        private void textBox_WorkNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_WorkNo.Text))
            {
                textBox_WorkNo.ButtonCustom.Visible = false;
            }
            else
            {
                textBox_WorkNo.ButtonCustom.Visible = true;
            }
        }
        private void expandablePanel_attends_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
        }
        private void expandablePanel_Sat_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!expandablePanel_attends.Expanded)
            {
                e.Cancel = true;
            }
        }
        private void button_BankCall_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBXBankNo.Text))
            {
                Button_Edit_Click(sender, e);
                textBox_AccSal.Text = txtBXBankNo.Text;
                textBox_AccSalName.Text = txtBXBankName.Text;
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }
    }
}
