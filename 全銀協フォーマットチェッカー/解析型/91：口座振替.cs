using System;
using System.Collections.Generic;
using System.Linq;

namespace �S�⋦�t�H�[�}�b�g
{
    partial class ���_91 : ��͌^
    {
        public ���R�[�h �w�b�_�[(List<char> Char�z��, int ���R�[�h�ԍ�)
        {
            ���R�[�h ���R�[�h = new(���R�[�h�ԍ�);

            ���R�[�h["�f�[�^�敪"] = new string(Char�z��.GetRange(0, 1).ToArray());
            //1�F�w�b�_�[�E���R�[�h
            //�f�[�^�Z�b�g��͎��Ƀ`�F�b�N���Ă���̂ŏȗ�

            ���R�[�h["��ʃR�[�h"] = new string(Char�z��.GetRange(1, 2).ToArray());
            //91�F�a�������U��
            if ("91" != ���R�[�h["��ʃR�[�h"]) { throw new Exception("��ʃR�[�h(������[1-2])�F1���R�[�h�ڂ̎�ʃR�[�h(91)�Ƃ͈قȂ�܂��B"); }

            ���R�[�h["�R�[�h�敪"] = new string(Char�z��.GetRange(3, 1).ToArray());
            //0�FJIS
            if ("0" != ���R�[�h["�R�[�h�敪"]
            //1�FEBCDIC
             && "1" != ���R�[�h["�R�[�h�敪"]) { throw new Exception("�R�[�h�敪(������[3])�F1���R�[�h�ڂ̃R�[�h�敪�Ƃ͈قȂ�܂��B"); }

            ���R�[�h["�ϑ��҃R�[�h"] = new string(Char�z��.GetRange(4, 10).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["�ϑ��҃R�[�h"]); } catch (Exception e) { throw new Exception("�ϑ��҃R�[�h(������[4-13])�F" + e.Message); }

            ���R�[�h["�ϑ��Җ�"] = new string(Char�z��.GetRange(14, 40).ToArray());
            //���l�ߎc��X�y�[�X(�t�^2.�Q��)
            if (' ' == ���R�[�h["�ϑ��Җ�"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�ϑ��Җ�"]); } catch { throw new Exception("�ϑ��Җ�(������[14-53])�F���l�߂���Ă��܂���B"); } }
            try { �������.��������������.�`�F�b�N(���R�[�h["�ϑ��Җ�"]); } catch (Exception e) { throw new Exception("�ϑ��Җ�(������[14-53])�F" + e.Message); }

            ���R�[�h["������"] = new string(Char�z��.GetRange(54, 4).ToArray());
            //MMDD�i��-���j
            try
            {
                �������.����.�`�F�b�N(���R�[�h["������"]);

                DateTime Date = new(DateTime.Now.Year, int.Parse(���R�[�h["������"].Substring(0, 2)), int.Parse(���R�[�h["������"].Substring(2, 2)));
                if (("0229" != ���R�[�h["������"]) &&
                    (int.Parse(���R�[�h["������"].Substring(0, 2)) != Date.Month
                  || int.Parse(���R�[�h["������"].Substring(2, 2)) != Date.Day)) { throw new Exception("�s���ȓ��t�ł��B\"" + ���R�[�h["������"] + "\""); }
            }
            catch (Exception e) { throw new Exception("������(������[54-57])�F" + e.Message); }

            ���R�[�h["�����s�ԍ�"] = new string(Char�z��.GetRange(58, 4).ToArray());
            //������Z�@�֔ԍ�
            try { �������.����.�`�F�b�N(���R�[�h["�����s�ԍ�"]); } catch (Exception e) { throw new Exception("�����s�ԍ�(������[58-61])�F" + e.Message); }

            ���R�[�h["�����s��"] = new string(Char�z��.GetRange(62, 15).ToArray());
            //���ȗ���
            //���l�ߎc��X�y�[�X
            if (' ' == ���R�[�h["�����s��"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�����s��"]); } catch { throw new Exception("�����s��(������[62-76])�F���l�߂���Ă��܂���B"); } }
            try { �������.�X�ܖ�������.�`�F�b�N(���R�[�h["�����s��"]); } catch (Exception e) { throw new Exception("�����s��(������[62-76])�F" + e.Message); }

            ���R�[�h["����x�X�ԍ�"] = new string(Char�z��.GetRange(77, 3).ToArray());
            //����X�ԍ�
            try { �������.����.�`�F�b�N(���R�[�h["����x�X�ԍ�"]); } catch (Exception e) { throw new Exception("����x�X�ԍ�(������[77-79])�F" + e.Message); }

            ���R�[�h["����x�X��"] = new string(Char�z��.GetRange(80, 15).ToArray());
            //���ȗ���
            //���l�ߎc��X�y�[�X
            if (' ' == ���R�[�h["����x�X��"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["����x�X��"]); } catch { throw new Exception("����x�X��(������[80-94])�F���l�߂���Ă��܂���B"); } }
            try { �������.�X�ܖ�������.�`�F�b�N(���R�[�h["����x�X��"]); } catch (Exception e) { throw new Exception("����x�X��(������[80-94])�F" + e.Message); }

            ���R�[�h["�a�����(�ϑ���)"] = new string(Char�z��.GetRange(95, 1).ToArray());
            //1�F���ʗa��
            if ("1" != ���R�[�h["�a�����(�ϑ���)"]
            //2�F�����a��
             && "2" != ���R�[�h["�a�����(�ϑ���)"]
            //9�F���̑�
             && "9" != ���R�[�h["�a�����(�ϑ���)"]) { throw new Exception("�ϑ��җa�����(������[95])�F�w��\�Ȑ�����[1�F���ʗa��][2�F�����a��][9�F���̑�]�ł��B"); }

            ���R�[�h["�����ԍ�(�ϑ���)"] = new string(Char�z��.GetRange(96, 7).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["�����ԍ�(�ϑ���)"]); } catch (Exception e) { throw new Exception("�ϑ��Ҍ����ԍ�(������[96-102])�F" + e.Message); }

            ���R�[�h["�_�~�["] = new string(Char�z��.GetRange(103, 17).ToArray());
            try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�_�~�["]); } catch (Exception e) { throw new Exception("�_�~�[(������[103-119])�F" + e.Message); }

            return ���R�[�h;
        }
        public ���R�[�h �f�[�^(List<char> Char�z��, int ���R�[�h�ԍ�)
        {
            ���R�[�h ���R�[�h = new(���R�[�h�ԍ�);

            ���R�[�h["�f�[�^�敪"] = new string(Char�z��.GetRange(0, 1).ToArray());
            //2�F�f�[�^�E���R�[�h
            //�f�[�^�Z�b�g��͎��Ƀ`�F�b�N���Ă���̂ŏȗ�

            ���R�[�h["������s�ԍ�"] = new string(Char�z��.GetRange(1, 4).ToArray());
            //������Z�@�֔ԍ�
            try { �������.����.�`�F�b�N(���R�[�h["������s�ԍ�"]); } catch (Exception e) { throw new Exception("������s�ԍ�(������[1-4])�F" + e.Message); }

            ���R�[�h["������s��"] = new string(Char�z��.GetRange(5, 15).ToArray());
            //���ȗ���
            //���l�ߎc��X�y�[�X
            if (' ' == ���R�[�h["������s��"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["������s��"]); } catch { throw new Exception("������s��(������[5-19])�F���l�߂���Ă��܂���B"); } }
            try { �������.�X�ܖ�������.�`�F�b�N(���R�[�h["������s��"]); } catch (Exception e) { throw new Exception("������s��(������[5-19])�F" + e.Message); }

            ���R�[�h["�����x�X�ԍ�"] = new string(Char�z��.GetRange(20, 3).ToArray());
            //����X�ԍ�
            try { �������.����.�`�F�b�N(���R�[�h["�����x�X�ԍ�"]); } catch (Exception e) { throw new Exception("�����x�X�ԍ�(������[20-22])�F" + e.Message); }

            ���R�[�h["�����x�X��"] = new string(Char�z��.GetRange(23, 15).ToArray());
            //���ȗ���
            //���l�ߎc��X�y�[�X
            if (' ' == ���R�[�h["�����x�X��"][0]) { try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�����x�X��"]); } catch { throw new Exception("�����x�X��(������[23-37])�F���l�߂���Ă��܂���B"); } }
            try { �������.�X�ܖ�������.�`�F�b�N(���R�[�h["�����x�X��"]); } catch (Exception e) { throw new Exception("�����x�X��(������[23-37])�F" + e.Message); }

            ���R�[�h["�_�~�[�P"] = new string(Char�z��.GetRange(38, 4).ToArray());
            try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�_�~�[�P"]); } catch (Exception e) { throw new Exception("�_�~�[�P(������[38-41])�F" + e.Message); }

            ���R�[�h["�a�����"] = new string(Char�z��.GetRange(42, 1).ToArray());
            //1�F���ʗa��
            if ("1" != ���R�[�h["�a�����"]
            //2�F�����a��
             && "2" != ���R�[�h["�a�����"]
            //3�F�[�ŏ����a��
             && "3" != ���R�[�h["�a�����"]
            //9�F���̑�
             && "9" != ���R�[�h["�a�����"]) { throw new Exception("�a�����(������[42])�F�w��\�Ȑ�����[1�F���ʗa��][2�F�����a��][3�F�[�ŏ����a��][9�F���̑�]�ł��B"); }

            ���R�[�h["�����ԍ�"] = new string(Char�z��.GetRange(43, 7).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["�����ԍ�"]); } catch (Exception e) { throw new Exception("�����ԍ�(������[43-49])�F" + e.Message); }

            ���R�[�h["�a���Җ�"] = new string(Char�z��.GetRange(50, 30).ToArray());
            //���l�ߎc��X�y�[�X(�t�^2�Q��)
            try { �������.��������������.�`�F�b�N(���R�[�h["�a���Җ�"]); } catch (Exception e) { throw new Exception("�a���Җ�(������[50-79])�F" + e.Message); }

            ���R�[�h["�������z"] = new string(Char�z��.GetRange(80, 10).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["�������z"]); } catch (Exception e) { throw new Exception("�������z(������[80-89])�F" + e.Message); }

            ���R�[�h["�V�K�R�[�h"] = new string(Char�z��.GetRange(90, 1).ToArray());
            //1�F��1�������
            if ("1" != ���R�[�h["�V�K�R�[�h"]
            //2�F�ύX��(������s�E�x�X�A�����ԍ�)
             && "2" != ���R�[�h["�V�K�R�[�h"]
            //0�F���̑�
             && "0" != ���R�[�h["�V�K�R�[�h"]) { throw new Exception("�V�K�R�[�h(������[90])�F�w��\�Ȑ�����[1�F��1�������][2�F�ύX��][0�F���̑�]�ł��B"); }

            ���R�[�h["�ڋq�ԍ�"] = new string(Char�z��.GetRange(91, 20).ToArray());
            //�E�l�ߎc��O�u0�v
            //�i���j�ڋq�ԍ��ȊO�̂��̂��L�ڂ��Ȃ��B
            try { �������.����.�`�F�b�N(���R�[�h["�ڋq�ԍ�"]); } catch (Exception e) { throw new Exception("�ڋq�ԍ�(������[91-110])�F" + e.Message); }

            ���R�[�h["�U�֌��ʃR�[�h"] = new string(Char�z��.GetRange(111, 1).ToArray());
            //�˗����ׂł́u0�v�Ƃ���B
            //0�F�U�֍�
            if ("0" != ���R�[�h["�U�֌��ʃR�[�h"]
            //1�F�����s��
             && "1" != ���R�[�h["�U�֌��ʃR�[�h"]
            //2�F����Ȃ�
             && "2" != ���R�[�h["�U�֌��ʃR�[�h"]
            //3�F�a���҂̓s���ɂ��U�֒�~
             && "3" != ���R�[�h["�U�֌��ʃR�[�h"]
            //4�F�a�������U�ֈ˗����Ȃ�
             && "4" != ���R�[�h["�U�֌��ʃR�[�h"]
            //8�F�ϑ��҂̓s���ɂ��U�֒�~
             && "8" != ���R�[�h["�U�֌��ʃR�[�h"]
            //9�F���̑�
             && "9" != ���R�[�h["�U�֌��ʃR�[�h"]) { throw new Exception("�U�֌��ʃR�[�h(������[111])�F�w��\�Ȑ�����[0�F�˗�/�U�֍�][1�F�����s��][2�F����Ȃ�][3�F�a���҂̓s���ɂ��U�֒�~][4�F�a�������U�ֈ˗����Ȃ�][8�F�ϑ��҂̓s���ɂ��U�֒�~][9�F���̑�]�ł��B"); }

            ���R�[�h["�_�~�[�Q"] = new string(Char�z��.GetRange(112, 8).ToArray());
            try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�_�~�[�Q"]); } catch (Exception e) { throw new Exception("�_�~�[�Q(������[112-119])�F" + e.Message); }

            return ���R�[�h;
        }
        public ���R�[�h �g���[��(List<char> Char�z��, int ���R�[�h�ԍ�)
        {
            ���R�[�h ���R�[�h = new(���R�[�h�ԍ�);

            ���R�[�h["�f�[�^�敪"] = new string(Char�z��.GetRange(0, 1).ToArray());
            //8�F�g���[���E���R�[�h
            //�f�[�^�Z�b�g��͎��Ƀ`�F�b�N���Ă���̂ŏȗ�

            ���R�[�h["���v����"] = new string(Char�z��.GetRange(1, 6).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["���v����"]); } catch (Exception e) { throw new Exception("���v����(������[1-6])�F" + e.Message); }

            ���R�[�h["���v���z"] = new string(Char�z��.GetRange(7, 12).ToArray());
            //�E�l�ߎc��O�u0�v
            try { �������.����.�`�F�b�N(���R�[�h["���v���z"]); } catch (Exception e) { throw new Exception("���v���z(������[7-18])�F" + e.Message); }

            ���R�[�h["�U�֍ό���"] = new string(Char�z��.GetRange(19, 6).ToArray());
            //�E�l�ߎc��O�u0�v
            //�˗����ׂł͑S�āu0�v�Ƃ���B
            try { �������.����.�`�F�b�N(���R�[�h["�U�֍ό���"]); } catch (Exception e) { throw new Exception("�U�֍ό���(������[19-24])�F" + e.Message); }

            ���R�[�h["�U�֍ϋ��z"] = new string(Char�z��.GetRange(25, 12).ToArray());
            //�E�l�ߎc��O�u0�v
            //�˗����ׂł͑S�āu0�v�Ƃ���D
            try { �������.����.�`�F�b�N(���R�[�h["�U�֍ϋ��z"]); } catch (Exception e) { throw new Exception("�U�֍ϋ��z(������[25-36])�F" + e.Message); }

            ���R�[�h["�U�֕s�\����"] = new string(Char�z��.GetRange(37, 6).ToArray());
            //�E�l�ߎc��O�u0�v
            //�˗����ׂł͑S�āu0�v�Ƃ���D
            try { �������.����.�`�F�b�N(���R�[�h["�U�֕s�\����"]); } catch (Exception e) { throw new Exception("�U�֕s�\����(������[37-42])�F" + e.Message); }

            ���R�[�h["�U�֕s�\����"] = new string(Char�z��.GetRange(43, 12).ToArray());
            //�E�l�ߎc��O�u0�v
            //�˗����ׂł͑S�āu0�v�Ƃ���D
            try { �������.����.�`�F�b�N(���R�[�h["�U�֕s�\����"]); } catch (Exception e) { throw new Exception("�U�֕s�\����(������[43-54])�F" + e.Message); }

            ���R�[�h["�_�~�["] = new string(Char�z��.GetRange(55, 65).ToArray());
            try { �������.�X�y�[�X.�`�F�b�N(���R�[�h["�_�~�["]); } catch (Exception e) { throw new Exception("�_�~�[(������[55-119])�F" + e.Message); }

            return ���R�[�h;
        }
        public ���R�[�h �G���h(List<char> Char�z��, int ���R�[�h�ԍ�)
        {
            ���R�[�h ���R�[�h = new(���R�[�h�ԍ�);

            ���R�[�h["�f�[�^�敪"] = new string(Char�z��.GetRange(0, 1).ToArray());
            //9�F�G���h�E���R�[�h
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
            if (�f�[�^�Z�b�g.�f�[�^�z��.Sum(�f�[�^ => decimal.Parse(�f�[�^["�������z"])) != decimal.Parse(�f�[�^�Z�b�g.�g���[��["���v���z"])) { throw new Exception("���v���z(������[1-6])�F�f�[�^[�������z]�̍��v�ƈ�v���܂���B"); }

            //�ȉ��`�F�b�N����Ă����B

            if (!(
                (
                    //�A-1�A�U�֑O�Ƃ��Đ��툵��
                    //�f�[�^�F�������ʂ��S��0
                    �f�[�^�Z�b�g.�f�[�^�z��.All(�f�[�^ => "0" == �f�[�^["�U�֌��ʃR�[�h"])
                    //�g���[���F[�U�֍ρA�U�֕s�\]��[�����A���z]��0�ł��邱�ƁB
                    && (0 == int.Parse(�f�[�^�Z�b�g.�g���[��["�U�֍ό���"]))
                    && (0 == decimal.Parse(�f�[�^�Z�b�g.�g���[��["�U�֍ϋ��z"]))
                    && (0 == int.Parse(�f�[�^�Z�b�g.�g���[��["�U�֕s�\����"]))
                    && (0 == decimal.Parse(�f�[�^�Z�b�g.�g���[��["�U�֕s�\����"]))
                ) || (
                        //�A-2�A�U�֌�Ƃ��Đ��툵��
                        //�f�[�^�F��������[0:�U�֍�]��[����ȊO:�U�֕s�\]�ŕ�����[�����A���z]
                        //�g���[���F[�U�֍ρA�U�֕s�\]��[�����A���z]�ƈ�v���Ă��邱�ƁB
                        (�f�[�^�Z�b�g.�f�[�^�z��.Count(�f�[�^ => "0" == �f�[�^["�U�֌��ʃR�[�h"]) == int.Parse(�f�[�^�Z�b�g.�g���[��["�U�֍ό���"]))
                     && (�f�[�^�Z�b�g.�f�[�^�z��.Sum(�f�[�^ => "0" == �f�[�^["�U�֌��ʃR�[�h"] ? decimal.Parse(�f�[�^["�������z"]) : 0) == decimal.Parse(�f�[�^�Z�b�g.�g���[��["�U�֍ϋ��z"]))
                     && (�f�[�^�Z�b�g.�f�[�^�z��.Count(�f�[�^ => "0" != �f�[�^["�U�֌��ʃR�[�h"]) == int.Parse(�f�[�^�Z�b�g.�g���[��["�U�֕s�\����"]))
                     && (�f�[�^�Z�b�g.�f�[�^�z��.Sum(�f�[�^ => "0" != �f�[�^["�U�֌��ʃR�[�h"] ? decimal.Parse(�f�[�^["�������z"]) : 0) == decimal.Parse(�f�[�^�Z�b�g.�g���[��["�U�֕s�\����"]))
                )
            )) { throw new Exception("�U�֍ό����E�U�֍ϋ��z�E�U�֕s�\�����E�U�֕s�\���ށF�f�[�^��[�����E���z]�̏W�v�ƈ�v���܂���B"); }

        }
        public void �_���`�F�b�N(List<�f�[�^�Z�b�g> �f�[�^�Z�b�g�z��, ���R�[�h �G���h) { }
    }
}