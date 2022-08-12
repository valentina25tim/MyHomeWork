
import React, { useEffect, useState} from "react";
import PostService from "../components/PostService";
import PostFilter from "../components/PostFilter";
import PostForm from "../components/PostForm";
import PostList from "../components/PostList";
import MyButton from "../components/UI/button/MyButton";
import Loader from "../components/UI/Loader/Loader";
import MyModal from "../components/UI/MyModal/MyModal";
import { useFetching } from "../hook/useFetching";
import { usePosts } from "../hook/usePosts";
import { getPageCount } from "../components/utils/pages";
import Pagination from "../components/UI/pagination/pagination";
import '../styles/app.css'

function Posts() {
  
  const [posts, setPosts] = useState([])
  const [filter, setFilter] = useState({sort: '', query: ''});
  const [modal, setModal] = useState(false);
  const [totalPages, setTotalPages] = useState(0);
  const [limit, setLimit] = useState(10);
  const [page, setPage] = useState(1);
  const sortedAndSearchedPosts = usePosts(posts, filter.sort, filter.query);
 
  const [fetchPosts, isPostsLoading, postError] = useFetching(async(limit, page)  => {
    const response = await PostService.getAll(limit, page);
    setPosts(response.data)
    
    const totalCount = response.headers['x-total-count']
    setTotalPages(getPageCount(totalCount, limit));
  })
  console.log(totalPages);

  useEffect(() => {
    fetchPosts(limit, page)
  },[])
  // }, [filter])

  const createPost= (newPost) => {
    setPosts([...posts, newPost ])
    setModal(false)
  }

  const removePost = (post) => {
    setPosts(posts.filter(p => p.id !== post.id)) 
  }

  const changePage = (page) => {
    setPage(page)
    fetchPosts(limit, page)
  }
  return (
    <div className="App">
      <MyButton style={{marginTop: 30}}onClick={() => setModal(true)}>
        Create new User
      </MyButton>

      <MyModal visible ={modal} setVisible={setModal}>
        <PostForm create={createPost}/>
      </MyModal>

      <hr style={{margin: '15px 0'}}/>

      <PostFilter 
        filter={filter} 
        setFilter={setFilter}
      />
      {postError && 
      <h3>SOMETHING WENT WRONG</h3>}
      {isPostsLoading
      ? <div style={{display: 'flex', justifyContent: 'center', marginTop: 50 }}><Loader/></div>
      : <PostList remove={removePost} posts={sortedAndSearchedPosts} title="Posts List"/>
      }
      <Pagination 
        totalPages={totalPages} 
        page={page} 
        changePage={changePage} 
      />
    </div> 
  );
}
export default Posts;
