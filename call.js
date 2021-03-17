let url = 'http://localhost:5544/kvs/testcall';

const http = require('http');

// testcall get
http.get(url, (res) => {
  res.on('data', (chunk)=>{
    console.log('response with data received');
    console.log(chunk.toString());
  })
});
