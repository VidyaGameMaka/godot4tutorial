public class SceneData {
    public SceneData(string path, string prettyName, bool pauseAllowed) {
        this.path = path;
        this.prettyName = prettyName;
        this.pauseAllowed = pauseAllowed;
    }
    public string path;
    public string prettyName;
    public bool pauseAllowed;
}