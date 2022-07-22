const React = require("react");
const axios = require('axios').default;


import TestCss from "./test.css";
import IndexCss from "./index.scss";

function Test()
{
    
    let funAjaxCall = function ()
    {
        axios.get("/WeatherForecast")
            .then(function (response)
            {
                alert("성공 : " + response.data.length);
                console.log(response.data);
            })
            .catch(function (error)
            {
                alert("알수 없는 오류가 발생했습니다.");
            });
    };

    return (
        <div >
            <div className={TestCss.Test}>
                App Css
            </div>
            <div className={IndexCss.Test}>
                Index Css
            </div>  

            <button onClick={funAjaxCall} >Ajax call</button>
        </div>
    );
}

export default Test;
