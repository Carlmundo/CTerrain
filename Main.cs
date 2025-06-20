using Syroot.Worms.Worms2;
using System.Diagnostics;
using System.Text;

namespace W2_Terrain_Loader
{
    public partial class Main : Form
    {
        private const int DefaultSpawnCount = 18;
        private const int DefaultMinDistance = 100;
        private const int CavernMinY = 17;
        private const int OpenMinY = 0;
        public Main()
        {
            InitializeComponent();
        }

        public static class Global
        {
            public static string fileGame = "Data\\land.dat";
            public static bool fileGameSet = true;
            public static string fileSelected = "";
            public static bool fileLocked = false;
            public static string dirLevels = @"Levels\Import";
            public static Random rnd = new Random();
            public static System.Media.SoundPlayer sndSave = new System.Media.SoundPlayer(@"Data\\Wav\\Speech\\yessir.wav");

        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (File.Exists("worms2.exe")) {
                if (File.Exists(Global.fileGame)) {
                    LoadLand(Global.fileGame);
                    LockCheck(true);
                }
                else {
                    Global.fileGameSet = false;
                    btnSave.Enabled = false;
                    btnLock.Enabled = false;
                }
                LoadFiles();                
            }
            else {
                MessageBox.Show("Could not find the Worms 2 folder. Please make sure you extract the CTerrain files so that CTerrain.exe is in the same folder as worms2.exe.");
                Application.Exit();
            }
            
        }

        private void Main_Closing(object sender, EventArgs e)
        {
            if (Global.fileLocked) { //Unlock if already locked
                LockFile();
            }
        }
        private void dirCheck()
        {
            if (!Directory.Exists(Global.dirLevels)) {
                Directory.CreateDirectory(Global.dirLevels);
            }
        }
        private void LoadFiles()
        {
            dirCheck();
            ListDirectory(treeLevels, Global.dirLevels);            
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);

            // Add subdirectories as root nodes
            foreach (var directory in rootDirectoryInfo.GetDirectories()) {
                treeView.Nodes.Add(CreateDirectoryNode(directory));
            }

            // Add files as root nodes
            foreach (var file in rootDirectoryInfo.GetFiles()) {

                if (Path.GetExtension(file.FullName) == ".dat") {
                    var fileNode = new TreeNode(Path.GetFileNameWithoutExtension(file.Name));
                    fileNode.Tag = file.FullName;
                    treeView.Nodes.Add(fileNode);
                }
            }
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories()) {
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            }
            foreach (var file in directoryInfo.GetFiles()) {
                if (Path.GetExtension(file.FullName) == ".dat") {
                    var fileNode = new TreeNode(Path.GetFileNameWithoutExtension(file.Name));
                    fileNode.Tag = file.FullName;
                    directoryNode.Nodes.Add(fileNode);
                }
            }
            return directoryNode;
        }
        private void LoadLand(string path)
        {
            try {
                using (FileStream fs = File.OpenRead(path)) {
                    LandData landData = new LandData(fs);
                    pbLand.Image = landData.Foreground.ToBitmap();
                    cbCavern.Checked = landData.TopBorder;
                }
            }
            catch (FileNotFoundException e) {
                pbLand.Image = null;
                if (!string.IsNullOrEmpty(e.FileName)) {
                    string relativePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), e.FileName);
                    if (Global.fileGameSet && relativePath == Global.fileGame) {
                        MessageBox.Show("The land.dat file was not found.");
                    }
                    else {
                        MessageBox.Show("File not found: " + relativePath);
                    } 
                } 
            }
            catch (Exception e) {
                pbLand.Image = null;
                MessageBox.Show(e.Message);
            }
        }

        private void treeLevels_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null) {
                string filePath = e.Node.Tag.ToString();
                LoadLand(filePath);
                btnSet.Enabled = true;
                Global.fileSelected = filePath;
            }
            else {
                btnSet.Enabled = false;
            }
        }

        private void LockCheck(bool changeText)
        {
            if (Global.fileGameSet || File.Exists(Global.fileGame)) {
                FileInfo fInfo = new FileInfo(Global.fileGame);
                Global.fileLocked = fInfo.IsReadOnly;
            }
            else {
                Global.fileLocked = false;
            }
            if (changeText) {
                string btnText = " File";
                btnLock.Text = (Global.fileLocked ? "Unlock" : "Lock") + btnText;
            }
        }

        private void LockFile()
        {
            LockCheck(false);
            try {
                var attributes = File.GetAttributes(Global.fileGame);
                if (Global.fileLocked) {
                    File.SetAttributes(Global.fileGame, attributes & ~FileAttributes.ReadOnly);
                }
                else {
                    File.SetAttributes(Global.fileGame, attributes | FileAttributes.ReadOnly);
                }
                LockCheck(true);
            }
            catch (FileNotFoundException e) {
                if (!string.IsNullOrEmpty(e.FileName)) {
                    string relativePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), e.FileName);
                    if (relativePath == Global.fileGame) {
                        Global.fileGameSet = false;
                        btnSave.Enabled = false;
                        btnLock.Enabled = false;
                        MessageBox.Show("The land.dat file was not found. GIG2");
                    }
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        private void btnLock_Click(object sender, EventArgs e) => LockFile();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFiles();
            if (treeLevels.SelectedNode == null || treeLevels.SelectedNode.Tag == null) {
                btnSet.Enabled = false;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (treeLevels.SelectedNode != null && treeLevels.SelectedNode.Tag != null) {
                if (File.Exists(Global.fileGame) && Global.fileLocked) { //Unlock if already locked to allow file copy
                    LockFile();
                }
                try {
                    string fileSet = treeLevels.SelectedNode.Tag.ToString();
                    string strLevelStyle;
                    File.Copy(fileSet, Global.fileGame, true);
                    LandData landData = new LandData(Global.fileGame);
                    bool landCavern = landData.TopBorder;
                    bool optCavern = cbCavern.Checked;
                    if (optCavern) {
                        strLevelStyle = "Cavern";
                    }
                    else {
                        strLevelStyle = "Open";
                    }
                    bool landChanged = false; //Set if any changes need to be saved
                    if (landCavern != optCavern) {
                        landData.TopBorder = optCavern;
                        if (!landCavern && optCavern && !cbSeed.Checked) {
                            //Set new spawns with the set seed "Open", to avoid Worms spawning above the border
                            List<Point> points = GenerateSpacedSpawnpoints(landData.CollisionMask.ToBitmap(true), DefaultSpawnCount, DefaultMinDistance, CavernMinY, "Open");
                            landData.ObjectLocations = points;
                        }
                        landChanged = true;
                    }
                    if (cbSeed.Checked) {
                        int yVal = optCavern ? CavernMinY : OpenMinY;
                        List<Point> points = GenerateSpacedSpawnpoints(landData.CollisionMask.ToBitmap(true), DefaultSpawnCount, DefaultMinDistance, yVal, txtSeed.Text);
                        landData.ObjectLocations = points;
                        landChanged = true;
                    }
                    if (landChanged) {
                        landData.Save(Global.fileGame);
                    }
                    Global.fileGameSet = true;
                    btnSave.Enabled = true;
                    btnLock.Enabled = true;
                    LockFile();
                    string landStatus = Path.GetFileNameWithoutExtension(fileSet) + " | " + strLevelStyle;
                    if (txtSeed.Text.Length > 0) {
                        landStatus += " | " + txtSeed.Text;
                    }
                    else {
                        if (cbSeed.Checked) {
                            landStatus += " | Random Seed";
                        }
                    }
                    lblCurrent.Text = landStatus;
                    flpStatus.Visible = true;
                    try { Global.sndSave.Play();}
                    catch { }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Generates spawn points spaced out over the map, all above solid ground, with a minimum distance between them.
        /// </summary>
        /// <param name="bitmap">The map bitmap.</param>
        /// <param name="numberOfSpawnPoints">Number of spawn points to generate.</param>
        /// <param name="minDistance">Minimum distance between spawn points.</param>
        /// <param name="minY">Minimum allowed Y value for spawn points (inclusive).</param>
        /// <param name="seed">Spawn seed (if set)</param>
        /// <returns>List of spawn points (Point).</returns>
        public static List<Point> GenerateSpacedSpawnpoints(Bitmap bitmap, int numberOfSpawnPoints, int minDistance, int minY = 0, string seed = "")
        {
            List<Point> spawnPositions = new List<Point>();
            Random rnd;
            if (seed.Length > 0) {
                rnd = GetRNG(seed);
            }
            else {
                rnd = Global.rnd;
            }
            int minDistanceCurrent = minDistance;
            int minDistanceLowerBound = 0;
            double relaxFactor = 0.9; // Reduce minDistance by 10% each time
            int maxAttemptsPerSpawn = 200;
            int globalAttempts = 0;
            int maxGlobalAttempts = numberOfSpawnPoints * 2000; // Only relax if this is exceeded
            int lastPlacedCount = 0;

            int thisAttempt = 0;

            while (spawnPositions.Count < numberOfSpawnPoints) {
                thisAttempt++;
                if (thisAttempt > 500)
                    return spawnPositions;

                int attempts = 0;
                Point? bestCandidate = null;
                double bestDist = -1;
                bool found = false;
                Point lastTried = Point.Empty;
                while (attempts < maxAttemptsPerSpawn) {
                    attempts++;
                    globalAttempts++;
                    int x = rnd.Next(0, bitmap.Width);
                    int y = rnd.Next(0, bitmap.Height);
                    Color a = bitmap.GetPixel(x, y);
                    if (!IsSolid(a)) continue;
                    if (!FindSafePosition(bitmap, x, y, out Point position)) continue;
                    if (position.Y < minY) continue;
                    if (spawnPositions.Contains(position)) {
                        lastTried = position;
                        continue;
                    }

                    // Find the minimum distance to existing spawns
                    double minDist = double.MaxValue;
                    foreach (var pt in spawnPositions) {
                        double d = Distance(pt, position);
                        if (d < minDist) minDist = d;
                    }
                    if (spawnPositions.Count == 0) minDist = double.MaxValue;

                    if (minDist >= minDistanceCurrent) {
                        spawnPositions.Add(position);
                        thisAttempt = 0;
                        found = true;
                        lastPlacedCount = globalAttempts;
                        break;
                    }
                    // Track the farthest candidate if we can't meet minDistance
                    if (minDist > bestDist && position.Y >= minY && !spawnPositions.Contains(position)) {
                        bestDist = minDist;
                        bestCandidate = position;
                    }
                }
                if (!found) {
                    if (bestCandidate.HasValue && !spawnPositions.Contains(bestCandidate.Value)) {
                        spawnPositions.Add(bestCandidate.Value);
                        thisAttempt = 0;
                        lastPlacedCount = globalAttempts;
                    }
                    else {
                        // Fallback: try to place at the next available Y above last tried position, ensuring uniqueness
                        if (lastTried != Point.Empty) {
                            Point fallback = lastTried;
                            bool placed = false;
                            for (int y = fallback.Y - 1; y >= minY; y--) {
                                Point tryPos = new Point(fallback.X, y);
                                if (!spawnPositions.Contains(tryPos)) {
                                    // Only place if it's over solid ground and FindSafePosition is true
                                    if (!IsSolid(bitmap.GetPixel(fallback.X, y))) {
                                        if (FindSafePosition(bitmap, fallback.X, y, out Point safePos) && safePos.Y >= minY && !spawnPositions.Contains(safePos)) {
                                            spawnPositions.Add(safePos);
                                            thisAttempt = 0;
                                            placed = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (placed) continue;
                        }
                        // If no candidate found at all, try a new random X (by continuing outer loop)
                        continue;
                    }
                }
                // Only relax if we've made no progress for a long time
                if (spawnPositions.Count < numberOfSpawnPoints && minDistanceCurrent > minDistanceLowerBound) {
                    if (globalAttempts - lastPlacedCount > maxGlobalAttempts) {
                        minDistanceCurrent = (int)Math.Max(minDistanceLowerBound, minDistanceCurrent * relaxFactor);
                        lastPlacedCount = globalAttempts;
                    }
                }
            }
            return spawnPositions;
        }

        private static double Distance(Point a, Point b)
        {
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static bool IsSolid(Color a)
        {
            return !(a.R == Color.Black.R && a.G == Color.Black.G && a.B == Color.Black.B);
        }

        public static bool FindSafePosition(Bitmap bitmap, int x, int y, out Point point)
        {
            int radius = 15;

            int yOffset = 30;

            for (int j = y; j > 0; j--) {
                if (!IsSolid(bitmap.GetPixel(x, j))) {
                    //We must now make sure that all tiles around are not solid
                    if (IsEnclosed(bitmap, x, j - yOffset, radius)) {
                        if (IsEnclosed(bitmap, x, j - yOffset - 20, radius)) {
                            point = Point.Empty;
                            return false;
                        }
                        else {
                            point = new Point(x, j - yOffset - 20);
                            return true;
                        }
                    }

                    point = new Point(x, j - yOffset);
                    return true;
                }
            }

            point = Point.Empty;
            return false;
        }

        static bool IsEnclosed(Bitmap bitmap, int x, int y, int radius)
        {
            // Check if all pixels within the specified radius are air
            for (int i = x - radius; i <= x + radius; i++) {
                for (int j = y - radius; j <= y + radius; j++) {
                    if (i >= 0 && i < bitmap.Width && j >= 0 && j < bitmap.Height) {
                        Color a = bitmap.GetPixel(i, j);
                        if (!(a.R == Color.Black.R && a.G == Color.Black.G && a.B == Color.Black.B)) {
                            // Solid pixel found, so it's not completely enclosed
                            return true;
                        }
                    }
                }
            }

            // All nearby pixels are air, so it's completely enclosed
            return false;
        }

        private static Random GetRNG(string seed)
        {
            var algo = System.Security.Cryptography.SHA1.Create();
            var hash = BitConverter.ToInt32(algo.ComputeHash(Encoding.UTF8.GetBytes(seed)), 0);
            return new Random(hash);
        }

        private void cbSeed_CheckedChanged(object sender, EventArgs e)
        {
            txtSeed.Visible = cbSeed.Checked;
            if (!cbSeed.Checked) {
                txtSeed.Text = "";
            }
        }

        private void cbSave_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the map", "Save file", "New Map", -1, -1);
            if (input.Length > 0) {
                string newFile = Global.dirLevels + "\\" + input + ".dat";
                bool fileCopy = true;
                if (File.Exists(newFile) && MessageBox.Show("The file already exists. Do you want to overwrite it?", "Overwrite file?", MessageBoxButtons.YesNo) == DialogResult.No) {
                    fileCopy = false;
                }
                if (fileCopy) {
                    File.Copy(Global.fileGame, newFile, true);
                    FileInfo newFileInfo = new FileInfo(newFile);
                    if (newFileInfo.IsReadOnly) { //Remove read only flag if set
                        File.SetAttributes(newFile, File.GetAttributes(newFile) & ~FileAttributes.ReadOnly);
                    }
                    LoadFiles();
                }
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            dirCheck();
            Process.Start("explorer.exe", Global.dirLevels);
        }
    }
}
