// Decompiled with JetBrains decompiler
// Type: TFG.ScriptNumber
// Assembly: TFG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7AEADE61-3C54-4F9F-84A9-41DF847D9A21
// Assembly location: C:\Program Files (x86)\AppSoft\InvAcc\TFG.dll

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InvAcc
{
    public class ScriptNumber
    {
        private string F;
        private string Taf1;
        private string Taf2;
        private string DD;
        private string D1;
        private string D2;
        private string D3;
        private string G;
        private string Grp;
        private string Grp1;
        private string Grp2;
        private string Grp3;
        private string Grp4;
        private string Grp5;
        private int r1;
        private int r2;
        private int r3;

        [DebuggerNonUserCode]
        public ScriptNumber()
        {
        }
        public string ScriptNums(object dblAmount)
        {
            label_1:
            int num1 = 0;
            string str1;
            int num2 = 0;
            try
            {
                ProjectData.ClearProjectError();
                num1 = -2;
                label_2:
                int num3 = 2;
                string str2 = string.Empty;
                label_3:
                num3 = 3;
                long num4 = Conversions.ToLong(Conversion.Fix(RuntimeHelpers.GetObjectValue(dblAmount)));
                label_4:
                num3 = 4;
                int Number = checked((int)unchecked(num4 / 1000000000L));
                label_5:
                num3 = 5;
                long num5 = num4 % 1000000000L;
                label_6:
                num3 = 6;
                if (Number <= 2)
                    goto label_19;
                label_7:
                num3 = 7;
                str2 += this.onetenhundred(Number);
                label_8:
                num3 = 8;
                int num6 = 0;
                if (num6 >= 3)
                    goto label_10;
                label_9:
                num3 = 9;
                str2 += "مليار ";
                goto label_18;
                label_10:
                num3 = 11;
                if (num6 >= 11)
                    goto label_12;
                label_11:
                num3 = 12;
                str2 += "مليارات ";
                goto label_18;
                label_12:
                num3 = 14;
                label_13:
                num3 = 15;
                if (num5 == 0L)
                    goto label_15;
                label_14:
                num3 = 16;
                str2 += "مليارا ";
                goto label_17;
                label_15:
                num3 = 18;
                label_16:
                num3 = 19;
                str2 += "مليار ";
                label_17:
                label_18:
                goto label_23;
                label_19:
                num3 = 23;
                if (Number != 2)
                    goto label_21;
                label_20:
                num3 = 24;
                str2 += "ملياران ";
                goto label_23;
                label_21:
                num3 = 26;
                if (Number != 1)
                    goto label_23;
                label_22:
                num3 = 27;
                str2 = str2 + this.onetenhundred(Number) + "مليار ";
                label_23:
                label_24:
                num3 = 29;
                if (!(num5 > 0L & Number > 0))
                    goto label_26;
                label_25:
                num3 = 30;
                str2 += "و";
                label_26:
                label_27:
                num3 = 32;
                Number = checked((int)unchecked(num5 / 1000000L));
                label_28:
                num3 = 33;
                num5 %= 1000000L;
                label_29:
                num3 = 34;
                num6 = Number % 100;
                label_30:
                num3 = 35;
                if (Number <= 2)
                    goto label_43;
                label_31:
                num3 = 36;
                str2 += this.onetenhundred(Number);
                label_32:
                num3 = 37;
                if (num6 >= 3)
                    goto label_34;
                label_33:
                num3 = 38;
                str2 += "مليون ";
                goto label_42;
                label_34:
                num3 = 40;
                if (num6 >= 11)
                    goto label_36;
                label_35:
                num3 = 41;
                str2 += "ملايين ";
                goto label_42;
                label_36:
                num3 = 43;
                label_37:
                num3 = 44;
                if (num5 == 0L)
                    goto label_39;
                label_38:
                num3 = 45;
                str2 += "ميلونا ";
                goto label_41;
                label_39:
                num3 = 47;
                label_40:
                num3 = 48;
                str2 += "مليون ";
                label_41:
                label_42:
                goto label_47;
                label_43:
                num3 = 52;
                if (Number != 2)
                    goto label_45;
                label_44:
                num3 = 53;
                str2 += "مليونان ";
                goto label_47;
                label_45:
                num3 = 55;
                if (Number != 1)
                    goto label_47;
                label_46:
                num3 = 56;
                str2 = str2 + this.onetenhundred(Number) + "مليون ";
                label_47:
                label_48:
                num3 = 58;
                if (!(num5 > 0L & Number > 0))
                    goto label_50;
                label_49:
                num3 = 59;
                str2 += "و";
                label_50:
                label_51:
                num3 = 61;
                Number = checked((int)unchecked(num5 / 1000L));
                label_52:
                num3 = 62;
                num5 %= 1000L;
                label_53:
                num3 = 63;
                if (Number <= 2)
                    goto label_66;
                label_54:
                num3 = 64;
                str2 += this.onetenhundred(Number);
                label_55:
                num3 = 65;
                if (Number % 100 >= 3)
                    goto label_57;
                label_56:
                num3 = 66;
                str2 += "ألف ";
                goto label_65;
                label_57:
                num3 = 68;
                if (Number % 100 >= 11)
                    goto label_59;
                label_58:
                num3 = 69;
                str2 += "آلاف ";
                goto label_65;
                label_59:
                num3 = 71;
                label_60:
                num3 = 72;
                if (num5 == 0L)
                    goto label_62;
                label_61:
                num3 = 73;
                str2 += "ألفا ";
                goto label_64;
                label_62:
                num3 = 75;
                label_63:
                num3 = 76;
                str2 += "ألف ";
                label_64:
                label_65:
                goto label_70;
                label_66:
                num3 = 80;
                if (Number != 2)
                    goto label_68;
                label_67:
                num3 = 81;
                str2 += "ألفان ";
                goto label_70;
                label_68:
                num3 = 83;
                if (Number != 1)
                    goto label_70;
                label_69:
                num3 = 84;
                str2 += "ألف ";
                label_70:
                label_71:
                num3 = 86;
                if (!(num5 > 0L & Number > 0))
                    goto label_73;
                label_72:
                num3 = 87;
                str2 += "و";
                label_73:
                label_74:
                num3 = 89;
                Number = checked((int)num5);
                label_75:
                num3 = 90;
                str2 += this.onetenhundred(Number);
                label_76:
                num3 = 91;
                double num7 = Conversions.ToDouble(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
                {
          Operators.SubtractObject(dblAmount, (object) num4),
          (object) 4
                }, (string[])null, (Type[])null, (bool[])null));
                label_77:
                num3 = 92;
                if (num7 <= 0.0)
                    goto label_81;
                label_78:
                num3 = 93;
                if (!Operators.ConditionalCompareObjectGreater(dblAmount, (object)1, false))
                    goto label_80;
                label_79:
                num3 = 94;
                str2 += "و ";
                label_80:
                num3 = 96;
                str2 = str2 + Conversions.ToString(Conversion.Fix(Math.Round(num7 * 100.0, 4))) + " هلله";
                label_81:
                label_82:
                str1 = str2;
                goto label_89;
                label_84:
                num2 = num3;
                switch (num1 > -2 ? num1 : 1)
                {
                    case 1:
                        int num8 = num2 + 1;
                        num2 = 0;
                        switch (num8)
                        {
                            case 1:
                                goto label_1;
                            case 2:
                                goto label_2;
                            case 3:
                                goto label_3;
                            case 4:
                                goto label_4;
                            case 5:
                                goto label_5;
                            case 6:
                                goto label_6;
                            case 7:
                                goto label_7;
                            case 8:
                                goto label_8;
                            case 9:
                                goto label_9;
                            case 10:
                            case 13:
                            case 21:
                                goto label_18;
                            case 11:
                                goto label_10;
                            case 12:
                                goto label_11;
                            case 14:
                                goto label_12;
                            case 15:
                                goto label_13;
                            case 16:
                                goto label_14;
                            case 17:
                            case 20:
                                goto label_17;
                            case 18:
                                goto label_15;
                            case 19:
                                goto label_16;
                            case 22:
                            case 25:
                            case 28:
                                goto label_23;
                            case 23:
                                goto label_19;
                            case 24:
                                goto label_20;
                            case 26:
                                goto label_21;
                            case 27:
                                goto label_22;
                            case 29:
                                goto label_24;
                            case 30:
                                goto label_25;
                            case 31:
                                goto label_26;
                            case 32:
                                goto label_27;
                            case 33:
                                goto label_28;
                            case 34:
                                goto label_29;
                            case 35:
                                goto label_30;
                            case 36:
                                goto label_31;
                            case 37:
                                goto label_32;
                            case 38:
                                goto label_33;
                            case 39:
                            case 42:
                            case 50:
                                goto label_42;
                            case 40:
                                goto label_34;
                            case 41:
                                goto label_35;
                            case 43:
                                goto label_36;
                            case 44:
                                goto label_37;
                            case 45:
                                goto label_38;
                            case 46:
                            case 49:
                                goto label_41;
                            case 47:
                                goto label_39;
                            case 48:
                                goto label_40;
                            case 51:
                            case 54:
                            case 57:
                                goto label_47;
                            case 52:
                                goto label_43;
                            case 53:
                                goto label_44;
                            case 55:
                                goto label_45;
                            case 56:
                                goto label_46;
                            case 58:
                                goto label_48;
                            case 59:
                                goto label_49;
                            case 60:
                                goto label_50;
                            case 61:
                                goto label_51;
                            case 62:
                                goto label_52;
                            case 63:
                                goto label_53;
                            case 64:
                                goto label_54;
                            case 65:
                                goto label_55;
                            case 66:
                                goto label_56;
                            case 67:
                            case 70:
                            case 78:
                                goto label_65;
                            case 68:
                                goto label_57;
                            case 69:
                                goto label_58;
                            case 71:
                                goto label_59;
                            case 72:
                                goto label_60;
                            case 73:
                                goto label_61;
                            case 74:
                            case 77:
                                goto label_64;
                            case 75:
                                goto label_62;
                            case 76:
                                goto label_63;
                            case 79:
                            case 82:
                            case 85:
                                goto label_70;
                            case 80:
                                goto label_66;
                            case 81:
                                goto label_67;
                            case 83:
                                goto label_68;
                            case 84:
                                goto label_69;
                            case 86:
                                goto label_71;
                            case 87:
                                goto label_72;
                            case 88:
                                goto label_73;
                            case 89:
                                goto label_74;
                            case 90:
                                goto label_75;
                            case 91:
                                goto label_76;
                            case 92:
                                goto label_77;
                            case 93:
                                goto label_78;
                            case 94:
                                goto label_79;
                            case 95:
                            case 96:
                                goto label_80;
                            case 97:
                                goto label_81;
                            case 98:
                                goto label_82;
                            case 99:
                                goto label_89;
                        }
                        break;
                }
            }
            catch (Exception ex) when (ex is Exception & (uint)num1 > 0U & num2 == 0)
            {
                ProjectData.SetProjectError(ex);

            }
            throw ProjectData.CreateProjectError(-2146828237);
            label_89:
            string str3 = str1;
            if (num2 == 0)
                return str3;
            ProjectData.ClearProjectError();
            return str3;
        }

        public string ScriptNum(object dblAmount)
        {
            label_1:
            int num1 = 0;
            string str1;
            int num2 = 0;
            try
            {
                ProjectData.ClearProjectError();
                num1 = -2;
                label_2:
                int num3 = 2;
                string str2 = string.Empty;
                label_3:
                num3 = 3;
                long num4 = Conversions.ToLong(Conversion.Fix(RuntimeHelpers.GetObjectValue(dblAmount)));
                label_4:
                num3 = 4;
                int Number = checked((int)unchecked(num4 / 1000000000L));
                label_5:
                num3 = 5;
                long num5 = num4 % 1000000000L;
                label_6:
                num3 = 6;
                if (Number <= 2)
                    goto label_19;
                label_7:
                num3 = 7;
                str2 += this.onetenhundred(Number);
                label_8:
                num3 = 8;
                int num6 = 0;
                if (num6 >= 3)
                    goto label_10;
                label_9:
                num3 = 9;
                str2 += "مليار ";
                goto label_18;
                label_10:
                num3 = 11;
                if (num6 >= 11)
                    goto label_12;
                label_11:
                num3 = 12;
                str2 += "مليارات ";
                goto label_18;
                label_12:
                num3 = 14;
                label_13:
                num3 = 15;
                if (num5 == 0L)
                    goto label_15;
                label_14:
                num3 = 16;
                str2 += "مليارا ";
                goto label_17;
                label_15:
                num3 = 18;
                label_16:
                num3 = 19;
                str2 += "مليار ";
                label_17:
                label_18:
                goto label_23;
                label_19:
                num3 = 23;
                if (Number != 2)
                    goto label_21;
                label_20:
                num3 = 24;
                str2 += "ملياران ";
                goto label_23;
                label_21:
                num3 = 26;
                if (Number != 1)
                    goto label_23;
                label_22:
                num3 = 27;
                str2 = str2 + this.onetenhundred(Number) + "مليار ";
                label_23:
                label_24:
                num3 = 29;
                if (!(num5 > 0L & Number > 0))
                    goto label_26;
                label_25:
                num3 = 30;
                str2 += "و";
                label_26:
                label_27:
                num3 = 32;
                Number = checked((int)unchecked(num5 / 1000000L));
                label_28:
                num3 = 33;
                num5 %= 1000000L;
                label_29:
                num3 = 34;
                num6 = Number % 100;
                label_30:
                num3 = 35;
                if (Number <= 2)
                    goto label_43;
                label_31:
                num3 = 36;
                str2 += this.onetenhundred(Number);
                label_32:
                num3 = 37;
                if (num6 >= 3)
                    goto label_34;
                label_33:
                num3 = 38;
                str2 += "مليون ";
                goto label_42;
                label_34:
                num3 = 40;
                if (num6 >= 11)
                    goto label_36;
                label_35:
                num3 = 41;
                str2 += "ملايين ";
                goto label_42;
                label_36:
                num3 = 43;
                label_37:
                num3 = 44;
                if (num5 == 0L)
                    goto label_39;
                label_38:
                num3 = 45;
                str2 += "ميلونا ";
                goto label_41;
                label_39:
                num3 = 47;
                label_40:
                num3 = 48;
                str2 += "مليون ";
                label_41:
                label_42:
                goto label_47;
                label_43:
                num3 = 52;
                if (Number != 2)
                    goto label_45;
                label_44:
                num3 = 53;
                str2 += "مليونان ";
                goto label_47;
                label_45:
                num3 = 55;
                if (Number != 1)
                    goto label_47;
                label_46:
                num3 = 56;
                str2 = str2 + this.onetenhundred(Number) + "مليون ";
                label_47:
                label_48:
                num3 = 58;
                if (!(num5 > 0L & Number > 0))
                    goto label_50;
                label_49:
                num3 = 59;
                str2 += "و";
                label_50:
                label_51:
                num3 = 61;
                Number = checked((int)unchecked(num5 / 1000L));
                label_52:
                num3 = 62;
                num5 %= 1000L;
                label_53:
                num3 = 63;
                if (Number <= 2)
                    goto label_66;
                label_54:
                num3 = 64;
                str2 += this.onetenhundred(Number);
                label_55:
                num3 = 65;
                if (Number % 100 >= 3)
                    goto label_57;
                label_56:
                num3 = 66;
                str2 += "ألف ";
                goto label_65;
                label_57:
                num3 = 68;
                if (Number % 100 >= 11)
                    goto label_59;
                label_58:
                num3 = 69;
                str2 += "آلاف ";
                goto label_65;
                label_59:
                num3 = 71;
                label_60:
                num3 = 72;
                if (num5 == 0L)
                    goto label_62;
                label_61:
                num3 = 73;
                str2 += "ألفا ";
                goto label_64;
                label_62:
                num3 = 75;
                label_63:
                num3 = 76;
                str2 += "ألف ";
                label_64:
                label_65:
                goto label_70;
                label_66:
                num3 = 80;
                if (Number != 2)
                    goto label_68;
                label_67:
                num3 = 81;
                str2 += "ألفان ";
                goto label_70;
                label_68:
                num3 = 83;
                if (Number != 1)
                    goto label_70;
                label_69:
                num3 = 84;
                str2 += "ألف ";
                label_70:
                label_71:
                num3 = 86;
                if (!(num5 > 0L & Number > 0))
                    goto label_73;
                label_72:
                num3 = 87;
                str2 += "و";
                label_73:
                label_74:
                num3 = 89;
                Number = checked((int)num5);
                label_75:
                num3 = 90;
                str2 += this.onetenhundred(Number);
                label_76:
                num3 = 91;
                double num7 = Conversions.ToDouble(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
                {
          Operators.SubtractObject(dblAmount, (object) num4),
          (object) 4
                }, (string[])null, (Type[])null, (bool[])null));
                label_77:
                num3 = 92;
                if (num7 <= 0.0)
                    goto label_81;
                label_78:
                num3 = 93;
                if (!Operators.ConditionalCompareObjectGreater(dblAmount, (object)1, false))
                    goto label_80;
                label_79:
                num3 = 94;
                str2 += "و ";
                label_80:
                num3 = 96;
                str2 = str2 + ScriptNums(Conversion.Fix(Math.Round(num7 * 100.0, 4))) + "هلله ";
                label_81:
                label_82:
                str1 = str2;
                goto label_89;
                label_84:
                num2 = num3;
                switch (num1 > -2 ? num1 : 1)
                {
                    case 1:
                        int num8 = num2 + 1;
                        num2 = 0;
                        switch (num8)
                        {
                            case 1:
                                goto label_1;
                            case 2:
                                goto label_2;
                            case 3:
                                goto label_3;
                            case 4:
                                goto label_4;
                            case 5:
                                goto label_5;
                            case 6:
                                goto label_6;
                            case 7:
                                goto label_7;
                            case 8:
                                goto label_8;
                            case 9:
                                goto label_9;
                            case 10:
                            case 13:
                            case 21:
                                goto label_18;
                            case 11:
                                goto label_10;
                            case 12:
                                goto label_11;
                            case 14:
                                goto label_12;
                            case 15:
                                goto label_13;
                            case 16:
                                goto label_14;
                            case 17:
                            case 20:
                                goto label_17;
                            case 18:
                                goto label_15;
                            case 19:
                                goto label_16;
                            case 22:
                            case 25:
                            case 28:
                                goto label_23;
                            case 23:
                                goto label_19;
                            case 24:
                                goto label_20;
                            case 26:
                                goto label_21;
                            case 27:
                                goto label_22;
                            case 29:
                                goto label_24;
                            case 30:
                                goto label_25;
                            case 31:
                                goto label_26;
                            case 32:
                                goto label_27;
                            case 33:
                                goto label_28;
                            case 34:
                                goto label_29;
                            case 35:
                                goto label_30;
                            case 36:
                                goto label_31;
                            case 37:
                                goto label_32;
                            case 38:
                                goto label_33;
                            case 39:
                            case 42:
                            case 50:
                                goto label_42;
                            case 40:
                                goto label_34;
                            case 41:
                                goto label_35;
                            case 43:
                                goto label_36;
                            case 44:
                                goto label_37;
                            case 45:
                                goto label_38;
                            case 46:
                            case 49:
                                goto label_41;
                            case 47:
                                goto label_39;
                            case 48:
                                goto label_40;
                            case 51:
                            case 54:
                            case 57:
                                goto label_47;
                            case 52:
                                goto label_43;
                            case 53:
                                goto label_44;
                            case 55:
                                goto label_45;
                            case 56:
                                goto label_46;
                            case 58:
                                goto label_48;
                            case 59:
                                goto label_49;
                            case 60:
                                goto label_50;
                            case 61:
                                goto label_51;
                            case 62:
                                goto label_52;
                            case 63:
                                goto label_53;
                            case 64:
                                goto label_54;
                            case 65:
                                goto label_55;
                            case 66:
                                goto label_56;
                            case 67:
                            case 70:
                            case 78:
                                goto label_65;
                            case 68:
                                goto label_57;
                            case 69:
                                goto label_58;
                            case 71:
                                goto label_59;
                            case 72:
                                goto label_60;
                            case 73:
                                goto label_61;
                            case 74:
                            case 77:
                                goto label_64;
                            case 75:
                                goto label_62;
                            case 76:
                                goto label_63;
                            case 79:
                            case 82:
                            case 85:
                                goto label_70;
                            case 80:
                                goto label_66;
                            case 81:
                                goto label_67;
                            case 83:
                                goto label_68;
                            case 84:
                                goto label_69;
                            case 86:
                                goto label_71;
                            case 87:
                                goto label_72;
                            case 88:
                                goto label_73;
                            case 89:
                                goto label_74;
                            case 90:
                                goto label_75;
                            case 91:
                                goto label_76;
                            case 92:
                                goto label_77;
                            case 93:
                                goto label_78;
                            case 94:
                                goto label_79;
                            case 95:
                            case 96:
                                goto label_80;
                            case 97:
                                goto label_81;
                            case 98:
                                goto label_82;
                            case 99:
                                goto label_89;
                        }
                        break;
                }
            }
            catch (Exception ex) when (ex is Exception & (uint)num1 > 0U & num2 == 0)
            {
                ProjectData.SetProjectError(ex);

            }
            throw ProjectData.CreateProjectError(-2146828237);
        label_89:
            string str3 = str1;
            if (num2 == 0)
                return str3;
            ProjectData.ClearProjectError();
            return str3 ;
        }

        private string onetenhundred(int Number)
        {
            string str = string.Empty;
            int num1 = Number % 10;
            int num2 = Number % 100 / 10;
            int num3 = Number / 100;
            switch (num3)
            {
                case 1:
                    str += "مائة ";
                    break;
                case 2:
                    str += "مائتان ";
                    break;
                case 3:
                    str += "ثلاثمائة ";
                    break;
                case 4:
                    str += "أربعمائة ";
                    break;
                case 5:
                    str += "خمسمائة ";
                    break;
                case 6:
                    str += "ستمائة ";
                    break;
                case 7:
                    str += "سبعمائة ";
                    break;
                case 8:
                    str += "ثمانمائة ";
                    break;
                case 9:
                    str += "تسعمائة ";
                    break;
            }
            if (num3 > 0 & num1 > 0)
                str += "و";
            switch (num1)
            {
                case 1:
                    str = num2 != 1 ? str + "واحد " : str + "أحد ";
                    break;
                case 2:
                    str = num2 != 1 ? str + "اثنان " : str + "اثنا ";
                    break;
                case 3:
                    str += "ثلاثة ";
                    break;
                case 4:
                    str += "أربعة ";
                    break;
                case 5:
                    str += "خمسة ";
                    break;
                case 6:
                    str += "ستة ";
                    break;
                case 7:
                    str += "سبعة ";
                    break;
                case 8:
                    str += "ثمانية ";
                    break;
                case 9:
                    str += "تسعة ";
                    break;
            }
            if (num2 > 1 & (num1 > 0 | num3 > 0))
                str += "و";
            switch (num2)
            {
                case 1:
                    str = num1 != 0 ? str + "عشر " : str + "وعشرة ";
                    break;
                case 2:
                    str += "عشرون ";
                    break;
                case 3:
                    str += "ثلاثون ";
                    break;
                case 4:
                    str += "أربعون ";
                    break;
                case 5:
                    str += "خمسون ";
                    break;
                case 6:
                    str += "ستون ";
                    break;
                case 7:
                    str += "سبعون ";
                    break;
                case 8:
                    str += "ثمانون ";
                    break;
                case 9:
                    str += "تسعون ";
                    break;
            }
            return str;
        }

        public string TafEng(Decimal Amt)
        {
            int num1 = 5;
            string taf1 = string.Empty;
            if (Decimal.Compare(Amt, 0M) != 0)
            {
                this.Taf1 = Strings.Trim(Conversions.ToString(Amt));
                this.Taf2 = string.Empty;
                this.r1 = 0;
                this.F = string.Empty;
                int num2 = Strings.Len(this.Taf1);
                int Start = 1;
                while (Start <= num2)
                {
                    if (Operators.CompareString(Strings.Mid(this.Taf1, Start, 1), ".", false) != 0 & num1 != 1)
                    {
                        this.Taf2 += Strings.Mid(this.Taf1, Start, 1);
                        checked { ++this.r1; }
                    }
                    else
                        num1 = 1;
                    if (num1 == 1 & Operators.CompareString(Strings.Mid(this.Taf1, Start, 1), ".", false) != 0)
                        this.F += Strings.Mid(this.Taf1, Start, 1);
                    checked { ++Start; }
                }
                if (Operators.CompareString(this.F, "00", false) == 0 | Operators.CompareString(this.F, "000", false) == 0)
                    this.F = string.Empty;
                this.Taf2 = Strings.Space(checked(15 - Strings.Len(this.Taf2))) + this.Taf2;
                this.Grp1 = Strings.Mid(this.Taf2, 13, 3);
                this.Grp5 = Strings.Mid(this.Taf2, 1, 3);
                this.Grp4 = Strings.Mid(this.Taf2, 4, 3);
                this.Grp3 = Strings.Mid(this.Taf2, 7, 3);
                this.Grp2 = Strings.Mid(this.Taf2, 10, 3);
                this.Taf2 = string.Empty;
                this.Taf1 = " ";
                int num3 = 5;
                do
                {
                    this.G = string.Empty;
                    this.Grp = "   ";
                    if (num3 == 5 & Conversion.Val(this.Grp5) > 0.0)
                    {
                        this.G = " TRILLION ";
                        this.Grp = this.Grp5;
                    }
                    if (num3 == 4 & Conversion.Val(this.Grp4) > 0.0)
                    {
                        this.G = " BILLION ";
                        this.Grp = this.Grp4;
                    }
                    if (num3 == 3 & Conversion.Val(this.Grp3) > 0.0)
                    {
                        this.G = " MILLION ";
                        this.Grp = this.Grp3;
                    }
                    if (num3 == 2 & Conversion.Val(this.Grp2) > 0.0)
                    {
                        this.G = " THOUSAND ";
                        this.Grp = this.Grp2;
                    }
                    if (num3 == 1)
                        this.Grp = this.Grp1;
                    if (Conversion.Val(this.Grp) != 0.0)
                    {
                        this.r3 = checked((int)Math.Round(Conversion.Val(Strings.Mid(this.Grp, 1, 1))));
                        this.r2 = checked((int)Math.Round(Conversion.Val(Strings.Mid(this.Grp, 2, 1))));
                        this.r1 = checked((int)Math.Round(Conversion.Val(Strings.Mid(this.Grp, 3, 1))));
                        this.D1 = string.Empty;
                        this.D2 = string.Empty;
                        this.D3 = string.Empty;
                        if (this.r3 != 0)
                        {
                            if (this.r3 == 1)
                                this.D1 += "HUNDRED ";
                            if (this.r3 == 2)
                                this.D1 += " TWO HUNDRED ";
                            if (this.r3 == 3)
                                this.D1 += " THREE HUNDRED ";
                            if (this.r3 == 4)
                                this.D1 += " FOUR HUNDRED ";
                            if (this.r3 == 5)
                                this.D1 += " FIVE HUNDRED ";
                            if (this.r3 == 6)
                                this.D1 += " SIX HUNDRED ";
                            if (this.r3 == 7)
                                this.D1 += " SEVEN HUNDRED ";
                            if (this.r3 == 8)
                                this.D1 += " EIGHT HUNDRED ";
                            if (this.r3 == 9)
                                this.D1 += " NINE HUNDRED ";
                        }
                        if (this.r2 == 1)
                        {
                            if (this.r1 == 0)
                                this.D3 += "TEN ";
                            if (this.r1 == 1)
                                this.D3 += "ELEVEN ";
                            if (this.r1 == 2)
                                this.D3 += "TWELVE ";
                            if (this.r1 == 3)
                                this.D3 += "THIRTEEN ";
                            if (this.r1 == 4)
                                this.D3 += "FOURTEEN ";
                            if (this.r1 == 5)
                                this.D3 += "FIFTEEN ";
                            if (this.r1 == 6)
                                this.D3 += "SIXTEEN ";
                            if (this.r1 == 7)
                                this.D3 += "SEVENTEEN ";
                            if (this.r1 == 8)
                                this.D3 += "EIGHTEEN ";
                            if (this.r1 == 9)
                                this.D3 += "NINETEEN ";
                        }
                        if (this.r2 > 1)
                        {
                            this.DD = string.Empty;
                            if (this.r2 == 2)
                                this.D3 = "TWENTY " + this.DD;
                            if (this.r2 == 3)
                                this.D3 = "THIRTY " + this.DD;
                            if (this.r2 == 4)
                                this.D3 = "FORTY " + this.DD;
                            if (this.r2 == 5)
                                this.D3 = "FIFTY " + this.DD;
                            if (this.r2 == 6)
                                this.D3 = "SIXTY " + this.DD;
                            if (this.r2 == 7)
                                this.D3 = "SEVENTY " + this.DD;
                            if (this.r2 == 8)
                                this.D3 = "EIGHTY " + this.DD;
                            if (this.r2 == 9)
                                this.D3 = "NINETY " + this.DD;
                        }
                        if (this.r1 > 0 & this.r2 != 1)
                        {
                            if (this.r1 == 1)
                                this.D2 += "ONE ";
                            if (this.r1 == 2)
                                this.D2 += "TWO ";
                            if (this.r1 == 3)
                                this.D2 += "THREE ";
                            if (this.r1 == 4)
                                this.D2 += "FOUR ";
                            if (this.r1 == 5)
                                this.D2 += "FIVE ";
                            if (this.r1 == 6)
                                this.D2 += "SIX ";
                            if (this.r1 == 7)
                                this.D2 += "SEVEN ";
                            if (this.r1 == 8)
                                this.D2 += "EIGHT ";
                            if (this.r1 == 9)
                                this.D2 += "NINE ";
                        }
                        this.Taf1 = this.Taf1 + Strings.Trim(this.D1) + " " + Strings.Trim(this.D3) + " " + Strings.Trim(this.D2) + this.G;
                        if (num3 == 5 & (Conversion.Val(this.Grp4) != 0.0 | Conversion.Val(this.Grp3) != 0.0 | Conversion.Val(this.Grp2) != 0.0 | Conversion.Val(this.Grp1) != 0.0))
                            this.Taf1 += "and ";
                        if (num3 == 4 & (Conversion.Val(this.Grp3) != 0.0 | Conversion.Val(this.Grp2) != 0.0 | Conversion.Val(this.Grp1) != 0.0))
                            this.Taf1 += "and ";
                        if (num3 == 3 & (Conversion.Val(this.Grp2) != 0.0 | Conversion.Val(this.Grp1) != 0.0))
                            this.Taf1 += "and ";
                        if (num3 == 2 & Conversion.Val(this.Grp1) != 0.0)
                            this.Taf1 += "and ";
                    }
                    checked { num3 += -1; }
                }
                while (num3 >= 1);
                if (Operators.CompareString(Strings.Trim(this.F), string.Empty, false) != 0)
                    this.F = " and " + this.F + "/1" + Strings.Mid("00000000", 1, Strings.Len(this.F)) + " ";
                this.Taf1 = Strings.Trim(this.Taf1 + this.F);
                this.Taf2 = this.Taf1;
                this.Taf1 = string.Empty;
                this.r2 = Strings.Len(Strings.Trim(this.Taf2));
                this.r1 = 1;
                this.r3 = 1;
                while (this.r1 <= this.r2 & this.r3 <= this.r2)
                {
                    this.Taf1 += Strings.Mid(this.Taf2, this.r3, 1);
                    if (Operators.CompareString(Strings.Mid(this.Taf2, this.r3, 1), Strings.Space(1), false) == 0 & Operators.CompareString(Strings.Mid(this.Taf2, checked(this.r3 + 1), 1), Strings.Space(1), false) == 0)
                        checked { ++this.r3; }
                    checked { ++this.r3; }
                    checked { ++this.r1; }
                }
                taf1 = this.Taf1;
            }
            return taf1;
        }
    }
}
