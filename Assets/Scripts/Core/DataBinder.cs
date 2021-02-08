using UnityEngine;

namespace PhysRehab.Core
{
    public class DataBinder : MonoBehaviour
    {
        [SerializeField]
        private object _dataSource;

        /// /// <summary>
        /// NOT INCAPSULATED
        /// </summary>
        public object DataSource
        {
            get => _dataSource;
            set => _dataSource = value;
        }
    }
}
