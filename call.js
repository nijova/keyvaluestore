const key = 'testKey';
let url = 'http://localhost:5544/kvs/' + key;

const http = require('http');
const delay = ms => new Promise(resolve => setTimeout(resolve, ms))


async function testGET() {
  http.get(url, (res) => {
    console.log('GET, statusCode:', res.statusCode);
    res.on('data', (chunk)=>{
      console.log(chunk.toString());
    })
  });
  await delay(5000);
}

async function testPUT() {
  const data = '=Well, hereComesTheString(data)...';

  const options = {
    hostname: 'localhost',
    port: 5544,
    path: '/kvs/' + key,
    method: 'PUT',
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
    }
  };

  const req = http.request(options, (res) => {
    console.log('PUT, statusCode:', res.statusCode);
    res.on('data', async (data) => {
      process.stdout.write(data);
    });
  });
  req.on('error', (e) => {
    console.error(e);
  });
  req.write(data)
  req.end();
  
  await delay(8000);
}

async function testDELETE() {
  const options = {
    hostname: 'localhost',
    port: 5544,
    path: '/kvs/' + key,
    method: 'DELETE'
  };

  const req = http.request(options, (res) => {
    console.log('DELETE, statusCode:', res.statusCode);
    res.on('data', async (data) => {
      process.stdout.write(data);
    });
  });
  req.on('error', (e) => {
    console.error(e);
  });
  req.end();
  
  await delay(5000);
}


async function runTestCalls() {
  console.log('testcall GET, should not find anything:');
  await testGET();
  console.log('*****');
  console.log('testcall PUT, should always succeed:');
  await testPUT();
  console.log('*****');
  console.log('testcall GET, now it should find entry:');
  await testGET();
  console.log('*****');
  console.log('testcall DELETE, should always succeed:');
  await testDELETE();
  console.log('*****');
  console.log('testcall GET, cannot find entry anymore:');
  await testGET();
  console.log('*****');
}

runTestCalls();