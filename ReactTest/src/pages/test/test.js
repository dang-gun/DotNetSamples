const React = require("react");

import parse from 'html-react-parser'
import { replace } from 'lodash';

import "./index.scss";
import TestHtml1 from './test1.html';
import TestHtml2 from './test2.html';

function Test()
{
    function TestCall(e)
    {
        alert("'TestCall'에서 호출됨");
    }

    let jsonData = {
        TestText: '테스트 텍스트입니다요~',
        TestInt: 124,
        TestFunc: TestCall
    }
    let aa = "<button onClick={TestCall}>버튼 이벤트 호출</button>";
    let bb = '<div><button onclick="console.log(\'hello\')">Hello World</button></div>';
    let cc = '<div><button onclick={TestFunc}>{TestText}</button></div>';

    var reactElement
        = parse(bb
            , {
                replace: domNode =>
                {
                    if ( domNode.name === 'button')
                    {
                        let temp = domNode.attribs.onclick;
                        
                        delete domNode.attribs.onclick;

                        //domNode.attribs.onClick
                        //    = domNode.attribs.onclick;
                        return (
                            <button
                                {...domNode.attribs}
                                onClick={() => { Function('"use strict";return (' + temp + ')')(); }}
                            >{domNode.children[0].data}</button>
                        );
                    }
                }
            });
    
    console.log(reactElement);


    let r = cc.match(/\{[\w]+\}/g);
    r && r.forEach((state) =>
    {
        var regex = new RegExp(state, 'g');
        var stateItem = state.split(/{|}/g)[1];
        cc = cc.replace(regex, jsonData[stateItem]);
    });
    console.log(cc);

    var reactElement2
        = parse(cc
            , {
                replace: domNode =>
                {
                    if (domNode.name === 'button')
                    {
                        console.log(domNode);
                        let temp = domNode.attribs.onclick;

                        delete domNode.attribs.onclick;

                        //domNode.attribs.onClick
                        //    = domNode.attribs.onclick;
                        return (
                            <button
                                {...domNode.attribs}
                                onClick={() => { Function('"use strict";return (' + temp + ')')(); }}
                            >{domNode.children[0].data}</button>
                        );
                    }
                }
            });

    console.log(reactElement);

    //return (
    //    <div className="Test">
    //        테스트 입니다.
    //        <br />
    //        <br />
    //        {parse(TestHtml1)}
    //        <br />
    //        <br />
    //        {parse(TestHtml2)}
    //    </div>
    //);

    return (
        <div className="Test">
            테스트 입니다.
            <br />
            <br />
            <button onClick={TestCall}>백엔드 호출 1</button>
            <br />
            <br />
            <div dangerouslySetInnerHTML={{ __html: aa }}></div>
            
            <br />
            <br />
            {reactElement}
            <br />
            <br />
            {reactElement2}
        </div>
    );
}

export default Test;
