using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace �S�⋦�t�H�[�}�b�g
{
    public struct �f�[�^�Z�b�g
    {
        public ���R�[�h �w�b�_�[;
        public List<���R�[�h> �f�[�^�z��;
        public ���R�[�h �g���[��;
        public �f�[�^�Z�b�g(���R�[�h �w�b�_�[, List<���R�[�h> �f�[�^�z��, ���R�[�h �g���[��)
        {
            this.�w�b�_�[ = �w�b�_�[;
            this.�f�[�^�z�� = �f�[�^�z��;
            this.�g���[�� = �g���[��;
        }
        public readonly IEnumerable<Dictionary<string, bool>> �f�[�^�z��_Keys
        {
            get
            {
                for (int i = 0; i < �f�[�^�z��.Max(�f�[�^ => �f�[�^.Count); i++)
                {
                    Dictionary<string, bool> Keys = new();
                    foreach (var Key in �f�[�^�z��.Where(�f�[�^ => i < �f�[�^.Count).Select(�f�[�^ => �f�[�^.ElementAt(i).Key))
                    {
                        Keys[Key] = true;
                    }
                    yield return Keys;
                }
            }
        }
    }
}