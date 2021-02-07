using UnityEngine;

namespace PhysRehab.Core
{
    public class DataBinder<T> : MonoBehaviour
    {
        [SerializeField]
        private T _dataSource;

        /// /// <summary>
        /// NOT INCAPSULATED
        /// </summary>
        public T DataSource
        {
            get => _dataSource;
            set => _dataSource = value;
        }
    }
}
