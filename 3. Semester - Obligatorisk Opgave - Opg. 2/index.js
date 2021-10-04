const baseUri = "http://jsonplaceholder.typicode.com/posts"

Vue.createApp({
    data(){
        return{
            posts:[],
            error: null,
            userId:""
        }
    },
    async created(){
    console.log("Created method, called")
    this.helperGetPosts(baseUri)
    },
    methods: {
        cleanList(){
            this.posts = []
            this.error = null
        },
        
    async getByUserID(uid){
        if(uid == null || uid == ""){
            this.error = "No UserID"
            this.posts = []
        }
        else{
            const uri = baseUri + "?userId=" + uid
            console.log("getByUserId" + uri)
            this.helperGetPosts(uri)
        }
    },
    async helperGetPosts(uri){
        try {
        const response = await axios.get(uri)
        this.post = await response.data
        this.error = null    
        } catch (ex) {
            this.posts = []
            this.error = ex.message
        }
    }
    }
}).mount("#app")