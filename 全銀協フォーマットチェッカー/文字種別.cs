using System;
using System.Collections.Generic;
using System.Linq;

namespace �S�⋦�t�H�[�}�b�g
{
    public class �������(uint �l)
    {
        private uint _�l => �l;
        public static implicit operator uint(������� �敪) => �敪._�l;
        public static implicit operator �������(uint �l) => new(�l);
        public static ������� operator &(������� ����, ������� �E��) => ����._�l & �E��._�l;
        public static ������� operator |(������� ����, ������� �E��) => ����._�l | �E��._�l;
        #region �萔
        public static readonly ������� ����` = 0b1;
        public static readonly ������� �X�y�[�X = 0b10;
        public static readonly ������� �V���O���N�H�[�g = 0b100;
        public static readonly ������� ���� = 0b1000; // ���� ����� ���ʕ�
        public static readonly ������� �v���X = 0b10000;
        public static readonly ������� �J���} = 0b100000;
        public static readonly ������� �n�C�t�� = 0b1000000;
        public static readonly ������� �s���I�h = 0b10000000;
        public static readonly ������� �X���b�V�� = 0b100000000;
        public static readonly ������� ���� = 0b1000000000;
        public static readonly ������� �R���� = 0b10000000000;
        public static readonly ������� �N�G�X�`���� = 0b100000000000;
        public static readonly ������� �p�啶�� = 0b1000000000000;
        public static readonly ������� �~�T�C�� = 0b10000000000000;
        public static readonly ������� �ꊇ�� = 0b100000000000000; // �ꊇ�� ����� �ꊇ�ʕ�
        public static readonly ������� �� = 0b1000000000000000;
        public static readonly ������� �J�i = 0b10000000000000000; // ��Ə������������B���_�Ɣ����_���܂ށB
        public static readonly ������� ���̑� = 0b100000000000000000;
        public static readonly ������� �X�y�[�X�܂��͐��� = �X�y�[�X | ����;
        /* ���P
         * �E�S�Ă̋Ɩ��i�X�ܖ��j
         * �E�S�Ă̋Ɩ��i�������A�U���˗��l���A��Ж��A�a���Җ��A���l���A�������A
         * �@�@�@�@�@�@�@�˗��l���A�����Ɖ�˗��l���A�ϑ��Җ��A�ؓ��Ҏ����A�ۏ؉�Ж��A�ϑ��於�A�����Ҏ����A�x���l���A�����˗��l���j
         * �@
         * �E�X�ܖ��Ŏg�p�ł��镶���́A
         * �@�J�i�i���Ə������������B
         * �@�@�@�@�������A�U�������ʒm�A���o��������ׁA�����U���A�U�������Ɖ�i�˗����ׁj
         * �@�@�@�@����ѐU�������Ɖ�i�������ʖ��ׁj�̊e�Ɩ��ɂ�����x�X���A�d���X���A�d���x�X������є�d���x�X���ɂ��ẮA�������������j
         * �@�A���_�A�����_�A�p�啶��(A�`Z)�A�����i0�`9�j�A�L���P��ށi -�kʲ�݁l�j�݂̂ł���B
         * �E���������Ŏg�p�ł��镶���́A
         * �@�J�i�i���Ə������������B
         * �@�@�@�@�������A�U�������ʒm�A���o��������ׁA�����U���A�U�������Ɖ�i�˗����ׁj
         * �@�@�@�@����ѐU�������Ɖ�i�������ʖ��ׁj�̊e�Ɩ��ɂ�����������A�U���˗��l���A���l������ь����Ɖ�˗��l���ɂ��ẮA�������������j
         * �@�A���_�A�����_�A�p�啶��(A�`Z)�A�����i0�`9�j�ASP�k��߰��l�A�L�� 4 ��ށi �i �j -�kʲ�݁l .�k��ص�ށl�j�݂̂ł���B
         */
         static readonly ������� �L���P��� = �n�C�t��;
         static readonly ������� �L���S��� = ���� | �n�C�t�� | �s���I�h;
        /// <summary>���Z�@�֖��́i�x�X���A�d���X���A�d���x�X���A��d���x�X���j</summary>
        public static readonly ������� �X�ܖ����Ȃ� = �J�i | �p�啶�� | ���� | �X�y�[�X | �L���P���;
        /// <summary>���Z�@�֖��́i�x�X���A�d���X���A�d���x�X���A��d���x�X���j<br/>
        /// 01:�U�������ʒm<br/>
        /// 03:���o���������<br/>
        /// 21:�����U��<br/>
        /// 98:�U�������Ɖ�i�˗����ׁj<br/>
        /// 99:�U�������Ɖ�i�������ʖ��ׁj<br/>
        /// </summary>
        public static readonly ������� �X�ܖ������� = �� | �X�ܖ����Ȃ�;
        /// <summary>�������`�l���́i�������A�U���˗��l���A���l���A�����Ɖ�˗��l���j</summary>
        public static readonly ������� �����������Ȃ� = �J�i | �p�啶�� | ���� | �X�y�[�X | �L���S���;
        /// <summary>�������`�l���́i�������A�U���˗��l���A���l���A�����Ɖ�˗��l���j<br/>
        /// 01:�U�������ʒm<br/>
        /// 03:���o���������<br/>
        /// 21:�����U��<br/>
        /// 98:�U�������Ɖ�i�˗����ׁj<br/>
        /// 99:�U�������Ɖ�i�������ʖ��ׁj<br/>
        ///</summary>
        public static readonly ������� �������������� = �� | �����������Ȃ�;
        /* ���Q�@���^�U���E�ܗ^�U���i���ԁE�n���������j�i��L�� 1.�̃t�B�[���h�������j
         * �g�p�ł��镶���́A
         * �J�i�i���Ə������������j�A���_�A�����_�A�����i0�`9�j�ASP�k��߰��l�݂̂ł���B
         */
        /// <summary>���P�̃t�B�[���h������<br/>
        /// 11:���^�U���i���ԁj<br/>
        /// 12:�ܗ^�U���i���ԁj<br/>
        /// 71:���^�U���i�n���������j<br/>
        /// 72:�ܗ^�U���i�n���������j<br/>
        ///</summary>
        public static readonly ������� ���Q = �J�i | ���� | �X�y�[�X;
        /* ���R�@�U�������ʒm�E���o��������ׁE�����U���E�U�������Ɖ�iEDI ���jEDI ���
         * �Ŏg�p�ł��镶���́A
         * �J�i�i�����܂ށB�������������j�A���_�A�����_�A�p�啶��(A�`Z)�A�����i0�`9�j�ASP�k��߰��l�A�L�� 8 ��ށi \ �u �v�i �j -�kʲ�݁l / .�k��ص�ށl)�݂̂ł���B
         * �i�� 1�j�L�� 8 ��ނɂ��ẮA�ꕔ�̋�s�Ŏg�p���Ă��Ȃ��L��������B
         * �i�� 2�j�J���}�i , �j�ɂ��ẮA�ꕔ�̋�s�V�X�e���� EDI ���̋�؂蕶���Ƃ��Ďg�p����Ă��邽�߁AEDI ���ł͎g�p���Ȃ��B
         */
         static readonly ������� �L���W��� = ���� | �n�C�t�� | �s���I�h | �X���b�V�� | �~�T�C�� | �ꊇ��;
        public static readonly ������� EDI��� = �� | �J�i | �p�啶�� | ���� | �X�y�[�X | �L���W���;
        /* ���S �O���ב֎�����ׁi��v���E���v���j�A�O���ב֊֘A���
         * �g�p�ł��镶���́A
         * �J�i�i���Ə������������j�A���_�A�����_�A�p�啶��(A�`Z)�A�����i0�`9�j�ASP�k��߰��l�A�L��4 ��ށi �i �j -�kʲ�݁l .�k��ص�ށl�j�݂̂ł���B
         */
        /* ���T �O�������˗�
         * �f�[�^�E���R�[�h�̂����A�����w�}����ɋL�ڂ��镶���́A
         * �p�啶��(A�`Z)�A�����i0�`9�j�ASP�k��߰��l�A�L�� 10 ���( / -�kʲ�݁l ? : ( ) .�k��ص�ށl , ' + )�݂̂����e����B
         */
        //public static readonly ������� �L���P�O��� = �V���O���N�H�[�g | ���� | �J���} | �v���X | �n�C�t�� | �s���I�h | �X���b�V�� | �R���� | �N�G�X�`����;
        /*���U �׈ב֗A���M�p�󔭍s�˗�(�������ύX�˗�)
         * �f�[�^�E���R�[�h�ɋL�ڂ��镶���́A
         * �p�啶��(A�`Z)�ASP�k��߰��l�A�L�� 10���( / -�kʲ�݁l ? : ( ) .�k��ص�ށl , ' + )�݂̂����e����B
         * �A���A�u���s��s�ւ̈˗������v(������(7)���� 5)�ɂ����Ă݂̂���ɉ����āA
         * �J�i(���Ə������������j�A���_�A�����_���g�p���邱�Ƃ��ł���B
         */
        /* ���V �O�ݗa�����o���������
         * �f�[�^�E���R�[�h�ɋL�ڂ��镶���́A
         * �J�i�i���Ə������������j�A���_�A�����_�A�p�啶��(A�`Z)�A�����i0�`9�j�ASP�k��߰��l�A�L�� 10 ���( / -�kʲ�݁l ? : ( ) .�k��ص�ށl , �f + )�݂̂����e����B
         */
        #endregion
        public static implicit operator �������(char Char) => Char switch
        {
            ' ' => �������.�X�y�[�X,
            '\'' => �������.�V���O���N�H�[�g,
            '(' => �������.����,
            ')' => �������.����,
            '+' => �������.�v���X,
            ',' => �������.�J���},
            '-' => �������.�n�C�t��,
            '.' => �������.�s���I�h,
            '/' => �������.�X���b�V��,
            var ���� when ('0' <= ���� && ���� <= '9') => �������.����,
            ':' => �������.�R����,
            '?' => �������.�N�G�X�`����,
            var ���� when ('A' <= ���� && ���� <= 'Z') => �������.�p�啶��,
            '\\' => �������.�~�T�C��,
            '�' => �������.�ꊇ��,
            '�' => �������.�ꊇ��,
            '�' => �������.��,
            var ���� when ('�' <= ���� && ���� <= '�') => �������.�J�i,
            '�' => �������.�J�i,
            '�' => �������.�J�i,
            _ => �������.���̑�,
        };
        public void �`�F�b�N(IEnumerable<char> Char�z��)
        {
            var �g�p�s���� = Char�z��.FirstOrDefault(Char => (�l & (�������)Char) == 0);
            if (�g�p�s���� != 0) { throw new Exception("�g�p�o���Ȃ�����[" + �g�p�s���� + "]���܂܂�Ă��܂��B"); }            
        }
    }
}