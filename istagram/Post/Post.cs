namespace istagram.Post;
class Post
{
    string _id;
    string _content;
    string _crTime;
    int _likeCount;
    int _viewCount;
    static List<string> _ids = new();
    static List<string> _posts = new();
    static List<int> _likes = new();
    static List<int> _views = new();
    public Post(string content)
    {
        _id = Guid.NewGuid().ToString();
        AddIdList(_id);
        _content = content;
        _crTime = DateTime.Now.ToString();
        _likeCount = 0;

        _posts.Add(_id + "\n" + _content + "\n" + _crTime);
        _likes.Add(_likeCount);
        _views.Add(_viewCount);
    }
    void AddIdList(string id) => _ids.Add(id);
    int IndexOfId(string id) => _ids.IndexOf(id);

    public static void ShowPosts()
    {
        for (int i = 0; i < _posts.Count; i++)
        {
            Console.WriteLine(_posts[i]);
            Console.WriteLine(_likes[i]);
            Console.WriteLine(_views[i]);
            Console.WriteLine();
        }
    }
    public static void LikePost(string id)
    {
        int i = _ids.IndexOf(id);
        if (i == -1) { throw new KeyNotFoundException("Id not founded"); }
        _likes[i]++;
        _views[i]++;
    }
    public static void DeletePost(string id)
    {
        int i = _ids.IndexOf(id);
        if (i == -1) { throw new KeyNotFoundException("Id not founded"); }
        _ids.RemoveAt(i);
        _posts.RemoveAt(i);
        _likes.RemoveAt(i);
        _views.RemoveAt(i);
    }
    //public void ShowPost() => Console.WriteLine($"Id: {_id}\nContent: {_content}\nCreation Time: {_crTime}\nLike count: {_likeCount}\nView count: {_viewCount}\n");

}
