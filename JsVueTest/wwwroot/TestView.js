
//<template>
//    <div>
//        <button @click="showTitle">Click</button>
//    <span>{{ title }}</span>
//  </div>
//</template >

//<script>
//  export default {
//    name: 'local-component',
//    data () {
//      return {
//        title: void 0
//      }
//    },
//    methods: {
//      showTitle () {
//        this.title = 'Local Component!!'
//      }
//    }
//  }
//</script>

//<style scoped>
//  div {
//    padding: 20px
//  }

//  div span {
//    margin: 20px
//  }
//</style>



export default function TestView()
{
    let aaa = `<div id="app"> 
        <h1>
        Render whatever you want
  </h1>
        <div v-html="span('Hello world')" /> 
</div>

<component-test>aaaa</component-test>`

    let bbb = `<div id="app"></div>`;

    Vue.createApp({
        
        template: bbb,
    }).mount("#divMain");

    //app.component("component-test", {
    //    data: {
    //        foo: 'asdasd'
    //    },
    //    methods: {
    //        span(text)
    //        {
    //            return `<span> ${text} </span>`
    //        }
    //    }
    //});


    //setTimeout(function ()
    //{
    //    app.divMain.html(aaa);

    //}, 0);
    
}