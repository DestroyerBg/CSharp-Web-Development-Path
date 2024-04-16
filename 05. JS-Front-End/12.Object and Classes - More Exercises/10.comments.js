function solve(input) {
    class Article{
        constructor(name){
            this.name = name;
            this.comments = {};
        }

        addComment(userName, commentAsObj){
           if (!this.comments.hasOwnProperty(userName)) {
                this.comments[userName] = [];
           }
           this.comments[userName].push(commentAsObj);
        }
    }
    const users = [];
    const articles = [];

    for (const line of input) {
        if (line.includes('user')) {
            const user = line.split(' ').pop();
            users.push(user);
        }else if(line.includes('article')){
            const articleName = line.split(' ').pop();
            const article = new Article(articleName);
            articles.push(article);
        }else if(line.includes('posts on')){
            const [userInfo, commentInfo] = line.split(': ');
            const userName = userInfo.split(' posts on ').shift();
            const articleName = userInfo.split(' posts on ').pop();
            const commentTitle = commentInfo.split(', ')[0];
            const commentContent = commentInfo.split(', ')[1];
            const comment = {
                'comment-title': commentTitle,
                'comment-Content': commentContent,
            }
            let searchArticle = articles.find(a => a.name === articleName);
            let searchUser = users.find(u => u == userName);
            if (searchUser && searchArticle) {
                searchArticle.addComment(userName, comment);
            }
        }
    }

    articles.sort((a,b) => Object.entries(b.comments).length - Object.entries(a.comments).length);
    for (const article of articles) {
        console.log(`Comments on ${article.name}`);
        const sortedComments = Object.entries(article.comments).sort((a,b) => a[0].localeCompare(b[0]));
        for (const comment of sortedComments) {
           const userComments = comment[1].map(c => Object.entries(c));
           userComments.forEach(element => {
            console.log(`--- From user ${comment[0]}: ${element[0][1]} - ${element[1][1]}`);
       });
        }
    }
    
}

solve(["user mike", "user lucy", "article a", "mike posts on a: hit, him",
"lucy posts on a: vic, goal", "lucy posts on a: Like, hop"]);