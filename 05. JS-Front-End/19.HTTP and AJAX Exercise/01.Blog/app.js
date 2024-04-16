function attachEvents() {
   const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
   const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

   const loadPostsButton = document.getElementById('btnLoadPosts');
   const viewPostButton = document.getElementById('btnViewPost');
   const selectMenu = document.getElementById('posts');
   const postTitle = document.getElementById('post-title');
   const postBody = document.getElementById('post-body');
   const commentsUl = document.getElementById('post-comments');

   let posts = [];

   loadPostsButton.addEventListener('click', (e) => {
    selectMenu.innerHTML = '';
    fetch(postsUrl)
    .then(res => res.json())
    .then(data => {
        posts = Object.values(data)
        posts.forEach(post => {
            const element = document.createElement('option');
            element.textContent = post.title;
            element.value = post.id;
            selectMenu.appendChild(element);
      });

    })
    .catch(e => console.log(e));
   })

   viewPostButton.addEventListener('click', (e) => {
    postTitle.textContent = '';
    postBody.textContent = '';
    commentsUl.innerHTML = '';
    const selectedIndex = selectMenu.selectedIndex;
    const selectedElement = selectMenu.options[selectedIndex];
    const findPost = posts.find(f => f.title == selectedElement.textContent);
    postTitle.textContent = findPost.title;
    postBody.textContent = findPost.body;

    fetch(commentsUrl)
    .then(res => res.json())
    .then(data => {
        Object.values(data)
        .filter(comment => comment.postId == findPost.id)
        .forEach(comment => {
            const liElement = document.createElement('li');
            liElement.textContent = comment.text;
            liElement.id = comment.id;
            commentsUl.appendChild(liElement);
        })
        });
        
    })
}



attachEvents();