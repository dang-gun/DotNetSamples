
async function Call(bAwait)
{
    let nCount = ++LogCount;

    console.log("start(" + nCount + "), bAwait(" + bAwait + ") : " + new Date());

    if (true === bAwait)
    {
        await AsyncTest(bAwait, nCount);
    }
    else if (false === bAwait)
    {
        AsyncTest(bAwait, nCount);
    }

    console.log("end(" + nCount + "), bAwait(" + bAwait + ") : " + new Date());
}

async function AsyncTest(bAwait, nCount)
{
    await sleep(3000);
    console.log("run(" + nCount + "), bAwait(" + bAwait + ") : " + new Date());
}

function sleep(ms)
{
    return new Promise(resolve => setTimeout(resolve, ms));
}