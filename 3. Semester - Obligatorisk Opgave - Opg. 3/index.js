Vue.createApp({
    data(){
        return{
            Input:'',
            Word:'',
            WordUpper: '',
            WordLower:''
        }
    },
    methods: {
        Function(){
            this.Word = this.Input
            this.WordUpper = this.Word.toUpperCase()
            this.WordLower = this.Word.toLowerCase()
        },
    }
}).mount("#app")