using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace �S�⋦�t�H�[�}�b�g
{
    public class �f�[�^
    {
        #region �v���p�e�B
        public List<�f�[�^�Z�b�g> �f�[�^�Z�b�g�z�� = new();
        public ���R�[�h �G���h;
        #endregion

        static readonly Dictionary<string, ��͌^> �Ή���ʃ��X�g = new Dictionary<string, ��͌^>{
            {"11" , new ���_11()},
            {"12" , new ���_12()},
            {"71" , new ���_71()},
            {"72" , new ���_72()},
            {"21" , new ���_21()},
            {"91" , new ���_91()},
        };
        public static IEnumerable<string> �Ή���ʃR�[�h => �Ή���ʃ��X�g.Keys;

        public �f�[�^(byte[] buf, int? ���R�[�h�T�C�Y = null, bool? CR = null, bool? LF = null)
        {
            #region ���R�[�h�T�C�Y��������
            if (null == ���R�[�h�T�C�Y)
            {
                if (120 < buf.Length && 0x0d == buf[120]) { ���R�[�h�T�C�Y = 120; }
                else if (200 < buf.Length && 0x0d == buf[200]) { ���R�[�h�T�C�Y = 200; }
                else if (250 < buf.Length && 0x0d == buf[250]) { ���R�[�h�T�C�Y = 250; }
                else if (300 < buf.Length && 0x0d == buf[300]) { ���R�[�h�T�C�Y = 300; }
                else if (550 < buf.Length && 0x0d == buf[550]) { ���R�[�h�T�C�Y = 550; }
                throw new Exception("���R�[�h�T�C�Y���������f�ł��܂���ł����B");
            }
            if (buf.Length < ���R�[�h�T�C�Y.Value * 3) { throw new Exception("�f�[�^�Z�b�g�ɕK�v�ȍŒ�t�@�C���T�C�Y�𖞂����Ă��܂���B"); }
            Encoding �G���R�[�_ = (buf[���R�[�h�T�C�Y.Value switch
            {
                200 => 3,
                120 => 3,
                550 => 3,
                300 => 6,
                250 => 3,
                _ => throw new Exception("���R�[�h�T�C�Y[" + ���R�[�h�T�C�Y.Value + "]�ɂ͑Ή����Ă��܂���B")
            }])
            #endregion
            #region �����R�[�h��������
            switch
            {
                0x30 => Encoding.GetEncoding(932),//JIS
                0xF1 => Encoding.GetEncoding(20290),//EBCDIC
                _ => throw new Exception("�����R�[�h�����ʂł��܂���B"),
            };
            #endregion
            #region ���s�L����������
            if (null == CR) { CR = "\r" == �G���R�[�_.GetString(new[] { buf[���R�[�h�T�C�Y.Value] }); }
            if (null == LF) { LF = "\n" == �G���R�[�_.GetString(new[] { buf[���R�[�h�T�C�Y.Value + (CR.Value ? 1 : 0)] }); }
            #endregion
            var buffer = buf.Select(Byte => �G���R�[�_.GetString(new[] { Byte })[0]).ToList();

            if (0x1a == buf.Last()) { buffer.RemoveRange(buffer.Count - 1, 1); }// �t�@�[���o���L���O�˗����ʂ̏ꍇ�̗�O����

            if ('1' != buffer[0]) { throw new Exception("�w�b�_�[������܂���B"); }
            var ��ʃR�[�h = new string(buffer.GetRange(1, ���R�[�h�T�C�Y.Value switch { 300 => 1, _ => 2 }).ToArray());
            ��͌^ ���; if (!�Ή���ʃ��X�g.TryGetValue(��ʃR�[�h, out ���)) { throw new Exception("���Ή��̎�ʃR�[�h�ł��B"); }

            int ���R�[�h�ԍ� = 0;
            try
            {
                ���R�[�h�ԍ�++;
                while ('1' == buffer[0])
                {
                    if (new string(buffer.GetRange(1, ���R�[�h�T�C�Y.Value switch { 300 => 1, _ => 2 }).ToArray()) != ��ʃR�[�h) { throw new Exception("��ʃR�[�h�Ɉ�ѐ�������܂���B"); }

                    if (buffer.Count < ���R�[�h�T�C�Y.Value) { throw new Exception("���R�[�h�T�C�Y������������܂���B"); }
                    var �w�b�_�[ = ���.�w�b�_�[(buffer.GetRange(0, ���R�[�h�T�C�Y.Value), ���R�[�h�ԍ�);
                    buffer.RemoveRange(0, ���R�[�h�T�C�Y.Value);
                    if (CR.Value) { if ('\r' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("���s�R�[�h'\\r'������܂���B"); } }
                    if (LF.Value) { if ('\n' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("���s�R�[�h'\\n'������܂���B"); } }

                    ���R�[�h�ԍ�++;
                    if (buffer.Count < ���R�[�h�T�C�Y.Value) { throw new Exception("���R�[�h�T�C�Y������������܂���B"); }
                    List<���R�[�h> �f�[�^�z�� = new();
                    while ('2' == buffer[0])
                    {
                        �f�[�^�z��.Add(���.�f�[�^(buffer.GetRange(0, ���R�[�h�T�C�Y.Value), ���R�[�h�ԍ�));
                        buffer.RemoveRange(0, ���R�[�h�T�C�Y.Value);
                        if (CR.Value) { if ('\r' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("���s�R�[�h'\\r'������܂���B"); } }
                        if (LF.Value) { if ('\n' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("���s�R�[�h'\\n'������܂���B"); } }

                        ���R�[�h�ԍ�++;
                        if (buffer.Count < ���R�[�h�T�C�Y.Value) { throw new Exception("���R�[�h�T�C�Y������������܂���B"); }
                    }

                    if ('8' != buffer[0]) { throw new Exception("�f�[�^�܂��̓g���[���ł͂���܂���B"); }
                    var �g���[�� = ���.�g���[��(buffer.GetRange(0, ���R�[�h�T�C�Y.Value), ���R�[�h�ԍ�);
                    buffer.RemoveRange(0, ���R�[�h�T�C�Y.Value);
                    if (CR.Value) { if ('\r' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("���s�R�[�h'\\r'������܂���B"); } }
                    if (LF.Value) { if ('\n' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("���s�R�[�h'\\n'������܂���B"); } }

                    �f�[�^�Z�b�g �f�[�^�Z�b�g = new(�w�b�_�[, �f�[�^�z��, �g���[��);
                    ���.�_���`�F�b�N(�f�[�^�Z�b�g);
                    �f�[�^�Z�b�g�z��.Add(�f�[�^�Z�b�g);

                    ���R�[�h�ԍ�++;
                    if (buffer.Count < ���R�[�h�T�C�Y.Value) { throw new Exception("���R�[�h�T�C�Y������������܂���B"); }
                }

                if ('9' != buffer[0]) { throw new Exception("�G���h���R�[�h������܂���B"); }
                �G���h = ���.�G���h(buffer.GetRange(0, ���R�[�h�T�C�Y.Value), ���R�[�h�ԍ�);
                buffer.RemoveRange(0, ���R�[�h�T�C�Y.Value);
                if (CR.Value) { if ('\r' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("���s�R�[�h'\\r'������܂���B"); } }
                if (LF.Value) { if ('\n' == buffer[0]) { buffer.RemoveRange(0, 1); } else { throw new Exception("���s�R�[�h'\\n'������܂���B"); } }

                ���.�_���`�F�b�N(�f�[�^�Z�b�g�z��, �G���h);
                if (0 < buffer.Count) { throw new Exception("�G���h���R�[�h�̌��Ƀf�[�^������܂��B"); }
            }
            catch (Exception e) { throw new Exception("���R�[�h�ԍ�[" + ���R�[�h�ԍ� + "]�F" + e.Message); }
        }
    }
}