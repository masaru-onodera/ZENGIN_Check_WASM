using System;
using System.Collections.Generic;
using System.Linq;

namespace �S�⋦�t�H�[�}�b�g
{
    partial class ���_11 : ���_A1 { public ���_11() : base("11", "���", "�U���w���", "��Ɠ�", new[] { "1", "2" }, "�a���Җ�", "�Ј��ԍ��A�����R�[�h", false) { } }
    partial class ���_12 : ���_A1 { public ���_12() : base("12", "���", "�U���w���", "��Ɠ�", new[] { "1", "2" }, "�a���Җ�", "�Ј��ԍ��A�����R�[�h", false) { } }
    partial class ���_71 : ���_A1 { public ���_71() : base("71", "���", "�U���w���", "��Ɠ�", new[] { "1", "2" }, "�a���Җ�", "�Ј��ԍ��A�����R�[�h", false) { } }
    partial class ���_72 : ���_A1 { public ���_72() : base("72", "���", "�U���w���", "��Ɠ�", new[] { "1", "2" }, "�a���Җ�", "�Ј��ԍ��A�����R�[�h", false) { } }
    partial class ���_21 : ���_A1 { public ���_21() : base("21", "�U���˗��l", "��g��", "��Ɠ�", new[] { "1", "2", "4", "9" }, "���l��", "�ڋq�R�[�h", true) { } }
    partial class ���_A1(
        string ��ʃR�[�h_�R�[�h,
        string �ϑ���_�ď�,
        string �U����_�ď�,
        string �˗���_�ď�,
        string[] �a�����_�R�[�h,
        string �U���於_�ď�,
        string ���p�Ҏ��ʗ̈�,
        bool �U���w��敪��EDI���
        ) : ��͌^
    {
        public ���R�[�h �w�b�_�[(List<char> Char�z��, int ���R�[�h�ԍ�)
        {
            ���R�[�h ���R�[�h = new(���R�[�h�ԍ�);

            ���R�[�h["�f�[�^�敪"] = new string(Char�z��.GetRange(0, 1).ToArray());
            //1�F�w�b�_�[�E���R�[�h
            //�f�[�^�Z�b�g��͎��Ƀ`�F�b�N���Ă���̂ŏȗ�

            ���R�[�h["��ʃR�[�h"] = new string(Char�z��.GetRange(1, 2).ToArray());
            //�ϐ��F��ʃR�[�h
            if (��ʃR�[�h_�R�[�h != ���R�[�h["��ʃR�[�h"]) { throw new Exception("��ʃR�[�h(������[1-2])�F1���R�[�h�ڂ̎�ʃR�[�h(" + ��ʃR�[�h_�R�[�h + ")�Ƃ͈قȂ�܂��B"); }

            ���R�[�h["�R�[�h�敪"] = new string(Char�z��.GetRange(3, 1).ToArray());
            //0�FJIS
            if ("0" != ���R�[�h["�R�[�h�敪"]
            //1�FEBCDIC
             && "1" != ���R�[�h["�R�[�h�敪"]) { throw new Exception("�R�[�h�敪(������[3])�F1���R�[�h�ڂ̃R�[�h�敪�Ƃ͈قȂ�܂��B"); }

            ���R�[�h[�ϑ���_�ď� + "�R�[�h"] = new string(Char�z��.GetRange(4, 10).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h[�ϑ���_�ď� + "�R�[�h"]); } catch (Exception e) { throw new Exception(�ϑ���_�ď� + "�R�[�h(������[4-13])�F" + e.Message); }

            ���R�[�h[�ϑ���_�ď� + "��"] = new string(Char�z��.GetRange(14, 40).ToArray());
            if (' ' == ���R�[�h[�ϑ���_�ď� + "��"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h[�ϑ���_�ď� + "��"]); } catch { throw new Exception(�ϑ���_�ď� + "��(������[14-53])�F���l�߂���Ă��܂���B"); } }
            try { �������.��������������.�`�F�b�N(���R�[�h[�ϑ���_�ď� + "��"]); } catch (Exception e) { throw new Exception(�ϑ���_�ď� + "��(������[14-53])�F" + e.Message); }

            ���R�[�h[�U����_�ď�] = new string(Char�z��.GetRange(54, 4).ToArray());
            //MMDD(��-��)
            try
            {
                �������.����.�`�F�b�N(���R�[�h[�U����_�ď�]);

                DateTime Date = new(DateTime.Now.Year, int.Parse(���R�[�h[�U����_�ď�].Substring(0, 2)), int.Parse(���R�[�h[�U����_�ď�].Substring(2, 2)));
                if (("0229" != ���R�[�h[�U����_�ď�]) &&
                    (int.Parse(���R�[�h[�U����_�ď�].Substring(0, 2)) != Date.Month
                  || int.Parse(���R�[�h[�U����_�ď�].Substring(2, 2)) != Date.Day)) { throw new Exception("�s���ȓ��t�ł��B\"" + ���R�[�h[�U����_�ď�] + "\""); }
            }
            catch (Exception e) { throw new Exception(�U����_�ď� + "(������[54-57])�F" + e.Message); }

            ���R�[�h["�d����s�ԍ�"] = new string(Char�z��.GetRange(58, 4).ToArray());
            //������Z�@�֔ԍ�
            try { �������.����.�`�F�b�N(���R�[�h["�d����s�ԍ�"]); } catch (Exception e) { throw new Exception("�d����s�ԍ�(������[58-61])�F" + e.Message); }

            ���R�[�h["�d����s��"] = new string(Char�z��.GetRange(62, 15).ToArray());
            //���ȗ���
            //���l�ߎc��X�y�[�X
            if (' ' == ���R�[�h["�d����s��"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�d����s��"]); } catch { throw new Exception("�d����s��(������[62-76])�F���l�߂���Ă��܂���B"); } }
            try { �������.�X�ܖ�������.�`�F�b�N(���R�[�h["�d����s��"]); } catch (Exception e) { throw new Exception("�d����s��(������[62-76])�F" + e.Message); }

            ���R�[�h["�d���x�X�ԍ�"] = new string(Char�z��.GetRange(77, 3).ToArray());
            //����X�ԍ�
            try { �������.����.�`�F�b�N(���R�[�h["�d���x�X�ԍ�"]); } catch (Exception e) { throw new Exception("�d���x�X�ԍ�(������[77-79])�F" + e.Message); }

            ���R�[�h["�d���x�X��"] = new string(Char�z��.GetRange(80, 15).ToArray());
            //���ȗ���
            //���l�ߎc��X�y�[�X
            if (' ' == ���R�[�h["�d���x�X��"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�d���x�X��"]); } catch { throw new Exception("�d���x�X��(������[80-94])�F���l�߂���Ă��܂���B"); } }
            try { �������.�X�ܖ�������.�`�F�b�N(���R�[�h["�d���x�X��"]); } catch (Exception e) { throw new Exception("�d���x�X��(������[80-94])�F" + e.Message); }

            ���R�[�h["�a�����(" + �˗���_�ď� + ")"] = new string(Char�z��.GetRange(95, 1).ToArray());
            //���ȗ���(�X�y�[�X)
            if (" " != ���R�[�h["�a�����(" + �˗���_�ď� + ")"]
            //1:���ʗa��
             && "1" != ���R�[�h["�a�����(" + �˗���_�ď� + ")"]
            //2:�����a��
             && "2" != ���R�[�h["�a�����(" + �˗���_�ď� + ")"]
            //9:���̑�
             && "9" != ���R�[�h["�a�����(" + �˗���_�ď� + ")"]) { throw new Exception(�˗���_�ď� + "�a�����(������[95])�F�w��\�ȕ�����[��߰��F�ȗ�][1�F���ʗa��][2�F�����a��][9�F���̑�]�ł��B"); }

            ���R�[�h["�����ԍ�(" + �˗���_�ď� + ")"] = new string(Char�z��.GetRange(96, 7).ToArray());
            //���ȗ���(�X�y�[�X)
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["�����ԍ�(" + �˗���_�ď� + ")"]); } catch (Exception e) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�����ԍ�(" + �˗���_�ď� + ")"]); } catch { throw new Exception(�˗���_�ď� + "�����ԍ�(������[96-102])�F" + e.Message); } }

            ���R�[�h["�_�~�["] = new string(Char�z��.GetRange(103, 17).ToArray());
            try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�_�~�["]); } catch (Exception e) { throw new Exception("�_�~�[(������[103-119])�F" + e.Message); }

            return ���R�[�h;
        }
        public ���R�[�h �f�[�^(List<char> Char�z��, int ���R�[�h�ԍ�)
        {
            ���R�[�h ���R�[�h = new(���R�[�h�ԍ�);

            ���R�[�h["�f�[�[�敪"] = new string(Char�z��.GetRange(0, 1).ToArray());
            //2�F�f�[�^�E���R�[�h
            //�f�[�^�Z�b�g��͎��Ƀ`�F�b�N���Ă���̂ŏȗ�

            ���R�[�h["��d����s�ԍ�"] = new string(Char�z��.GetRange(1, 4).ToArray());
            //������Z�@�֔ԍ�
            try { �������.����.�`�F�b�N(���R�[�h["��d����s�ԍ�"]); } catch (Exception e) { throw new Exception("��d����s�ԍ�(������[1-4])�F" + e.Message); }

            ���R�[�h["��d����s��"] = new string(Char�z��.GetRange(5, 15).ToArray());
            //���ȗ���
            //���l�ߎc��X�y�[�X
            if (' ' == ���R�[�h["��d����s��"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["��d����s��"]); } catch { throw new Exception("��d����s��(������[5-19])�F���l�߂���Ă��܂���B"); } }
            try { �������.�X�ܖ�������.�`�F�b�N(���R�[�h["��d����s��"]); } catch (Exception e) { throw new Exception("��d����s��(������[5-19])�F" + e.Message); }

            ���R�[�h["��d���x�X�ԍ�"] = new string(Char�z��.GetRange(20, 3).ToArray());
            //����X�ԍ�
            try { �������.����.�`�F�b�N(���R�[�h["��d���x�X�ԍ�"]); } catch (Exception e) { throw new Exception("��d���x�X�ԍ�(������[20-22])�F" + e.Message); }

            ���R�[�h["��d���x�X��"] = new string(Char�z��.GetRange(23, 15).ToArray());
            //���ȗ���
            //���l�ߎc��X�y�[�X
            if (' ' == ���R�[�h["��d���x�X��"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["��d���x�X��"]); } catch { throw new Exception("��d���x�X��(������[23-37])�F���l�߂���Ă��܂���B"); } }
            try { �������.�X�ܖ�������.�`�F�b�N(���R�[�h["��d���x�X��"]); } catch (Exception e) { throw new Exception("��d���x�X��(������[23-37])�F" + e.Message); }

            ���R�[�h["��`�������ԍ�"] = new string(Char�z��.GetRange(38, 4).ToArray());
            //���ȗ���
            try { �������.����.�`�F�b�N(���R�[�h["��`�������ԍ�"]); } catch (Exception e) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["��`�������ԍ�"]); } catch { throw new Exception("��`�������ԍ�(������[38-41])�F" + e.Message); } }

            ���R�[�h["�a�����"] = new string(Char�z��.GetRange(42, 1).ToArray());
            if (�a�����_�R�[�h.All(code => code != ���R�[�h["�a�����"]))
            {
                string message = "�a�����(������[42])�F�w��\�Ȑ�����";
                foreach (var code in �a�����_�R�[�h)
                {
                    message += code switch
                    {
                        "1" => "[1�F���ʗa��]",
                        "2" => "[2�F�����a��]",
                        "4" => "[4�F���~�a��]",
                        "9" => "[9�F���̑�]",
                        _ => "[" + code + "]",
                    };
                }
                message += "�ł��B";
                throw new Exception(message);
            }

            ���R�[�h["�����ԍ�"] = new string(Char�z��.GetRange(43, 7).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["�����ԍ�"]); } catch (Exception e) { throw new Exception("�����ԍ�(������[43-49])�F" + e.Message); }

            ���R�[�h[�U���於_�ď�] = new string(Char�z��.GetRange(50, 30).ToArray());
            //���l�ߎc��X�y�[�X(�t�^2�Q��)
            try { �������.��������������.�`�F�b�N(���R�[�h[�U���於_�ď�]); } catch (Exception e) { throw new Exception(�U���於_�ď� + "(������[50-79])�F" + e.Message); }

            ���R�[�h["�U�����z"] = new string(Char�z��.GetRange(80, 10).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["�U�����z"]); } catch (Exception e) { throw new Exception("�U�����z(������[80-89])�F" + e.Message); }

            ���R�[�h["�V�K�R�[�h"] = new string(Char�z��.GetRange(90, 1).ToArray());
            //1:��1��U����
            if ("1" != ���R�[�h["�V�K�R�[�h"]
            //2:�ύX��(��d����s�E�x�X�A�a����ځE�����ԍ�)
             && "2" != ���R�[�h["�V�K�R�[�h"]
            //0:���̑�
             && "0" != ���R�[�h["�V�K�R�[�h"]) { throw new Exception("�V�K�R�[�h(������[90])�F�w��\�Ȑ�����[1�F��1��U����][2�F�ύX��][0�F���̑�]�ł��B"); }

            //�E����15�̎��ʕ\�����ɁuY�v�\����t�����ꍇ�ɂ́A�{���̓��e�́u�˗��l������l�ɑ΂��Ēʒm����EDI���v��\�킷�B
            switch (Char�z��.GetRange(112, 1)[0])
            {
                case 'Y' when �U���w��敪��EDI���:
                    ���R�[�h["EDI���"] = new string(Char�z��.GetRange(91, 20).ToArray());
                    //���l�ߎc��X�y�[�X
                    try { �������.EDI���.�`�F�b�N(���R�[�h["EDI���"]); } catch (Exception e) { throw new Exception("EDI���(������[91-110])�F" + e.Message); }
                    break;
                case ' ':
                default:
                    ���R�[�h[���p�Ҏ��ʗ̈�] = new string(Char�z��.GetRange(91, 20).ToArray());
                    //���˗��l����߂����l���ʂ̂��߂̌ڋq�R�[�h��\�킷�B
                    //�E�l�ߎc��O�u0�v
                    //�i���j�ڋq�ԍ��ȊO�̂��̂��L�ڂ��Ȃ��B
                    try { �������.����.�`�F�b�N(���R�[�h[���p�Ҏ��ʗ̈�]); } catch (Exception e) { throw new Exception(���p�Ҏ��ʗ̈� + "(������[91-110])�F" + e.Message); }
                    break;
            }
            if (�U���w��敪��EDI���)
            {
                ���R�[�h["�U���w��敪"] = new string(Char�z��.GetRange(111, 1).ToArray());
                //���ȗ���
                if (" " != ���R�[�h["�U���w��敪"]
                 //7:�e���U��
                 && "7" != ���R�[�h["�U���w��敪"]
                 //8:�����U��
                 && "8" != ���R�[�h["�U���w��敪"]) { throw new Exception("�U���w��敪(������[111])�F�w��\�Ȑ�����[��߰��F�ȗ�][7�F�e���U��][8�F�����U��]�ł��B"); }

                ���R�[�h["���ʕ\��"] = new string(Char�z��.GetRange(112, 1).ToArray());
                //���ȗ���
                if (" " != ���R�[�h["���ʕ\��"]
                 //�{���ɁuY�v�\����t�����ꍇ�́A����12�E13�̍��ړ��e�́uEDI���v��\�킷�B
                 && "Y" != ���R�[�h["���ʕ\��"]) { throw new Exception("���ʕ\��(������[112])�F�w��\�Ȑ�����[��߰��F�ڋq�R�[�h][Y�FEDI���]�ł��B"); }

                ���R�[�h["�_�~�["] = new string(Char�z��.GetRange(113, 7).ToArray());
                try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�_�~�["]); } catch (Exception e) { throw new Exception("�_�~�[(������[113-119])�F" + e.Message); }
            }
            else
            {
                ���R�[�h["�_�~�["] = new string(Char�z��.GetRange(111, 9).ToArray());
                try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�_�~�["]); } catch (Exception e) { throw new Exception("�_�~�[(������[111-119])�F" + e.Message); }
            }
            return ���R�[�h;
        }
        public ���R�[�h �g���[��(List<char> Char�z��, int ���R�[�h�ԍ�)
        {
            ���R�[�h ���R�[�h = new(���R�[�h�ԍ�);

            ���R�[�h["�f�[�[�敪"] = new string(Char�z��.GetRange(0, 1).ToArray());
            //8�F�g���[���E���R�[�h
            //�f�[�^�Z�b�g��͎��Ƀ`�F�b�N���Ă���̂ŏȗ�

            ���R�[�h["���v����"] = new string(Char�z��.GetRange(1, 6).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["���v����"]); } catch (Exception e) { throw new Exception("���v����(������[1-6])�F" + e.Message); }

            ���R�[�h["���v���z"] = new string(Char�z��.GetRange(7, 12).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["���v���z"]); } catch (Exception e) { throw new Exception("���v���z(������[7-18])�F" + e.Message); }

            ���R�[�h["�_�~�["] = new string(Char�z��.GetRange(19, 101).ToArray());
            try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�_�~�["]); } catch (Exception e) { throw new Exception("�_�~�[(������[19-119])�F" + e.Message); }

            return ���R�[�h;
        }
        public ���R�[�h �G���h(List<char> Char�z��, int ���R�[�h�ԍ�)
        {
            ���R�[�h ���R�[�h = new(���R�[�h�ԍ�);

            ���R�[�h["�f�[�^�敪"] = new string(Char�z��.GetRange(0, 1).ToArray());
            //9:�G���h�E���R�[�h
            //�f�[�^�Z�b�g��͎��Ƀ`�F�b�N���Ă���̂ŏȗ�

            ���R�[�h["�_�~�["] = new string(Char�z��.GetRange(1, 119).ToArray());
            try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�_�~�["]); } catch (Exception e) { throw new Exception("�_�~�[(������[1-119])�F" + e.Message); }

            return ���R�[�h;
        }
        public void �_���`�F�b�N(�f�[�^�Z�b�g �f�[�^�Z�b�g)
        {
            //�@
            //�f�[�^�F�����Ƌ��z
            //�g���[���F���v�����ƍ��v���z�A�ƈ�v���Ă��邱�ƁB
            if (�f�[�^�Z�b�g.�f�[�^�z��.Count != int.Parse(�f�[�^�Z�b�g.�g���[��["���v����"])) { throw new Exception("���v����(������[1-6])�F�f�[�^�����ƈ�v���܂���B"); }
            if (�f�[�^�Z�b�g.�f�[�^�z��.Sum(�f�[�^ => decimal.Parse(�f�[�^["�U�����z"])) != decimal.Parse(�f�[�^�Z�b�g.�g���[��["���v���z"])) { throw new Exception("���v���z(������[1-6])�F�f�[�^[�U�����z]�̍��v�ƈ�v���܂���B"); }
        }
        public void �_���`�F�b�N(List<�f�[�^�Z�b�g> �f�[�^�Z�b�g�z��, ���R�[�h �G���h) { }
    }
}