using UnityEngine;

namespace PhysRehab.Core
{
    public class DataBinder : MonoBehaviour
    {
        [SerializeField]
        private Object _dataSource;

        /// /// <summary>
        /// NOT INCAPSULATED
        /// </summary>
        public Object DataSource
        {
            get => _dataSource;
            set => _dataSource = value;
        }
    }
}
