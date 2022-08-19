using DeviceManagement;

namespace GUI
{
    public partial class Form1 : Form
    {
        private DeviceManager _manager = new DeviceManager();

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            listView1.View = View.List;
            listView1.Items.Clear();
            var devices = _manager.GetDevices();
            devices.DistinctBy( d => d.Name ?? d.Description ).ToList()
                   .OrderBy( d => d.Name ?? d.Description )
                   .ToList()
                   .ForEach( d => listView1.Items.Add( d.Name ?? d.Description ) );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Init();
        }

        private void button2_Click( object sender, EventArgs e )
        {
            ChangeStateOfSelectedItems( false );
        }

        private void button3_Click( object sender, EventArgs e )
        {
            ChangeStateOfSelectedItems( true );
        }

        private void ChangeStateOfSelectedItems( bool disable )
        {
            var selectedDevices = new List<string>();
            for ( var i = 0; i < listView1.SelectedItems.Count; i++ )
            {
                selectedDevices.Add( listView1.SelectedItems[i].Text );
            }

            var devices = _manager.GetDevices();
            var devicesPhysicalName = devices.Where( d => selectedDevices.Contains( d.Name ?? d.Description ) ).ToList();

            foreach ( var dpn in devicesPhysicalName )
            {
                _manager.ChangeDeviceState( dpn.PhysicalName, disable );
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}