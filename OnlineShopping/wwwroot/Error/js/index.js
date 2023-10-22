/* Shapes */
var svgContainer = document.getElementById('svgContainer');
var animItem = bodymovin.loadAnimation({
  wrapper: svgContainer,
  animType: 'svg',
  loop: true,
  path: 'js/girl.json'
});
animItem.setSubframe(false);
animItem.setSpeed(0.8)
window.onresize = function(){
  animItem.resize()
}