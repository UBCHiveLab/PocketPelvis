"use strict";function Lightbox(){function z(){return window.innerHeight||document.documentElement.offsetHeight}function A(){return window.innerWidth||document.documentElement.offsetWidth}function B(a,b,c,d){a.addEventListener?a.addEventListener(b,c,d||!1):a.attachEvent&&a.attachEvent("on"+b,c)}function C(a,b){return a&&b?new RegExp("(^|\\s)"+b+"(\\s|$)").test(a.className):void 0}function D(a,b){return a&&b?(a.className=a.className.replace(new RegExp("(?:^|\\s)"+b+"(?!\\S)"),""),a):void 0}function E(a,b){return a&&b?(C(a,b)||(a.className+=" "+b),a):void 0}function F(a){return"undefined"!=typeof a?!0:!1}function G(a,b){if(!a||!F(a))return!1;var c;return a.getAttribute?c=a.getAttribute(b):a.getAttributeNode&&(c=a.getAttributeNode(b).value),F(c)&&""!=c?c:!1}function H(a,b){if(!a||!F(a))return!1;var c;return a.getAttribute?c=a.getAttribute(b):a.getAttributeNode&&(c=a.getAttributeNode(b).value),"string"==typeof c?!0:!1}function I(a){B(a,"click",function(){h=G(a,"data-jslghtbx-group")||!1,i=a,S(a,!1,!1,!1)},!1)}function J(a){a.stopPropagation?a.stopPropagation():a.returnValue=!1}function K(b){for(var c=[],d=0;d<a.thumbnails.length;d++)G(a.thumbnails[d],"data-jslghtbx-group")===b&&c.push(a.thumbnails[d]);return c}function L(a,b){for(var c=K(b),d=0;d<c.length;d++)if(G(a,"src")===G(c[d],"src")&&G(a,"data-jslghtbx")===G(c[d],"data-jslghtbx"))return d}function M(){if(h){var a=new Image,b=new Image,c=L(i,h);c===k.length-1?(a.src=k[k.length-1].src,b.src=k[0].src):0===c?(a.src=k[k.length-1].src,b.src=k[1].src):(a.src=k[c-1].src,b.src=k[c+1].src)}}function N(){if(!b){O();var d=function(){if(E(a.box,"jslghtbx-loading"),!c&&"number"==typeof a.opt.loadingAnimation){var b=0;o=setInterval(function(){E(p[b],"jslghtbx-active"),setTimeout(function(){D(p[b],"jslghtbx-active")},a.opt.loadingAnimation),b=b>=p.length?0:b+=1},a.opt.loadingAnimation)}};q=setTimeout(d,500)}}function O(){if(!b&&(D(a.box,"jslghtbx-loading"),!c&&"string"!=typeof a.opt.loadingAnimation&&a.opt.loadingAnimation)){clearInterval(o);for(var d=0;d<p.length;d++)D(p[d],"jslghtbx-active")}}function P(){if(!r){if(r=document.createElement("span"),E(r,"jslghtbx-next"),a.opt.nextImg){var b=document.createElement("img");b.setAttribute("src",a.opt.nextImg),r.appendChild(b)}else E(r,"jslghtbx-no-img");B(r,"click",function(b){J(b),a.next()},!1),a.box.appendChild(r)}if(E(r,"jslghtbx-active"),!s){if(s=document.createElement("span"),E(s,"jslghtbx-prev"),a.opt.prevImg){var c=document.createElement("img");c.setAttribute("src",a.opt.prevImg),s.appendChild(c)}else E(s,"jslghtbx-no-img");B(s,"click",function(b){J(b),a.prev()},!1),a.box.appendChild(s)}E(s,"jslghtbx-active")}function Q(){if(a.opt.responsive&&r&&s){var b=z()/2-r.offsetHeight/2;r.style.top=b+"px",s.style.top=b+"px"}}function R(c){function f(a){return"boolean"==typeof a?a:!0}if(c||(c={}),a.opt={boxId:c.boxId||!1,controls:f(c.controls),dimensions:f(c.dimensions),captions:f(c.captions),prevImg:"string"==typeof c.prevImg?c.prevImg:!1,nextImg:"string"==typeof c.nextImg?c.nextImg:!1,hideCloseBtn:c.hideCloseBtn||!1,closeOnClick:"boolean"==typeof c.closeOnClick?c.closeOnClick:!0,loadingAnimation:void 0===c.loadingAnimation?!0:c.loadingAnimation,animElCount:c.animElCount||4,preload:f(c.preload),carousel:f(c.carousel),animation:c.animation||400,nextOnClick:f(c.nextOnClick),responsive:f(c.responsive),maxImgSize:c.maxImgSize||.8,keyControls:f(c.keyControls),onopen:c.onopen||!1,onclose:c.onclose||!1,onload:c.onload||!1,onresize:c.onresize||!1,onloaderror:c.onloaderror||!1},a.opt.boxId)a.box=document.getElementById(a.opt.boxId);else if(!a.box&&!document.getElementById("jslghtbx")){var g=document.createElement("div");g.setAttribute("id","jslghtbx"),g.setAttribute("class","jslghtbx"),a.box=g,d.appendChild(a.box)}if(a.box.innerHTML=e,b&&E(a.box,"jslghtbx-ie8"),a.wrapper=document.getElementById("jslghtbx-contentwrapper"),!a.opt.hideCloseBtn){var h=document.createElement("span");h.setAttribute("id","jslghtbx-close"),h.setAttribute("class","jslghtbx-close"),h.innerHTML="X",a.box.appendChild(h),B(h,"click",function(b){J(b),a.close()},!1)}if(!b&&a.opt.closeOnClick&&B(a.box,"click",function(){a.close()},!1),"string"==typeof a.opt.loadingAnimation)n=document.createElement("img"),n.setAttribute("src",a.opt.loadingAnimation),E(n,"jslghtbx-loading-animation"),a.box.appendChild(n);else if(a.opt.loadingAnimation){a.opt.loadingAnimation="number"==typeof a.opt.loadingAnimation?a.opt.loadingAnimation:200,n=document.createElement("div"),E(n,"jslghtbx-loading-animation");for(var i=0;i<a.opt.animElCount;)p.push(n.appendChild(document.createElement("span"))),i++;a.box.appendChild(n)}a.opt.responsive?(B(window,"resize",function(){a.resize()},!1),E(a.box,"jslghtbx-nooverflow")):D(a.box,"jslghtbx-nooverflow"),a.opt.keyControls&&(B(document,"keydown",function(b){J(b),l&&39==b.keyCode&&a.next()},!1),B(document,"keydown",function(b){J(b),l&&37==b.keyCode&&a.prev()},!1),B(document,"keydown",function(b){J(b),l&&27==b.keyCode&&a.close()},!1))}function S(e,f,m,n){if(!e&&!f)return!1;h=f||h||G(e,"data-jslghtbx-group"),h&&(k=K(h),"boolean"!=typeof e||e||(e=k[0])),j.img=new Image,i=e;var o;o="string"==typeof e?e:G(e,"data-jslghtbx")?G(e,"data-jslghtbx"):G(e,"src"),g=!1,l||("number"==typeof a.opt.animation&&E(j.img,"jslghtbx-animate-transition jslghtbx-animate-init"),l=!0,a.opt.onopen&&a.opt.onopen()),a.opt&&F(a.opt.hideOverflow)&&!a.opt.hideOverflow||d.setAttribute("style","overflow: hidden"),a.box.setAttribute("style","padding-top: 0"),a.wrapper.innerHTML="",a.wrapper.appendChild(j.img),a.opt.animation&&E(a.wrapper,"jslghtbx-animate");var p=G(e,"data-jslghtbx-caption");if(p&&a.opt.captions){var r=document.createElement("p");r.setAttribute("class","jslghtbx-caption"),r.innerHTML=p,a.wrapper.appendChild(r)}E(a.box,"jslghtbx-active"),b&&E(a.wrapper,"jslghtbx-active"),a.opt.controls&&k.length>1&&(P(),Q()),j.img.onerror=function(){a.opt.onloaderror&&a.opt.onloaderror(n)},j.img.onload=function(){if(j.originalWidth=this.naturalWidth||this.width,j.originalHeight=this.naturalHeight||this.height,b||c){var d=new Image;d.setAttribute("src",o),j.originalWidth=d.width,j.originalHeight=d.height}var e=setInterval(function(){C(a.box,"jslghtbx-active")&&(E(a.wrapper,"jslghtbx-wrapper-active"),"number"==typeof a.opt.animation&&E(j.img,"jslghtbx-animate-transition"),m&&m(),O(),clearTimeout(q),a.opt.preload&&M(),a.opt.nextOnClick&&(E(j.img,"jslghtbx-next-on-click"),B(j.img,"click",function(b){J(b),a.next()},!1)),a.opt.onload&&a.opt.onload(n),clearInterval(e),a.resize())},10)},j.img.setAttribute("src",o),N()}var n,o,q,t,u,x,y,a=this,b=!1,c=!1,d=document.getElementsByTagName("body")[0],e='<div class="jslghtbx-contentwrapper" id="jslghtbx-contentwrapper" ></div>',g=!1,h=!1,i=!1,j={},k=[],l=!1,p=[],r=!1,s=!1;a.opt={},a.box=!1,a.wrapper=!1,a.thumbnails=[],a.load=function(d){navigator.appVersion.indexOf("MSIE 8")>0&&(b=!0),navigator.appVersion.indexOf("MSIE 9")>0&&(c=!0),R(d);for(var e=document.getElementsByTagName("img"),f=0;f<e.length;f++)H(e[f],"data-jslghtbx")&&(a.thumbnails.push(e[f]),I(e[f]))},a.open=function(a,b){a&&b&&(b=!1),S(a,b,!1,!1)},a.resize=function(){if(j.img){t=A(),u=z();var b=a.box.offsetWidth,c=a.box.offsetHeight;!g&&j.img&&j.img.offsetWidth&&j.img.offsetHeight&&(g=j.img.offsetWidth/j.img.offsetHeight),Math.floor(b/g)>c?(x=c*g,y=c):(x=b,y=b/g),x=Math.floor(x*a.opt.maxImgSize),y=Math.floor(y*a.opt.maxImgSize),(a.opt.dimensions&&y>j.originalHeight||a.opt.dimensions&&x>j.originalWidth)&&(y=j.originalHeight,x=j.originalWidth),j.img.setAttribute("width",x),j.img.setAttribute("height",y),j.img.setAttribute("style","margin-top:"+(z()-y)/2+"px"),setTimeout(Q,200),a.opt.onresize&&a.opt.onresize()}},a.next=function(){if(h){var b=L(i,h)+1;if(k[b])i=k[b];else{if(!a.opt.carousel)return;i=k[0]}"number"==typeof a.opt.animation?(D(j.img,"jslghtbx-animating-next"),setTimeout(function(){var b=function(){setTimeout(function(){E(j.img,"jslghtbx-animating-next")},a.opt.animation/2)};S(i,!1,b,"next")},a.opt.animation/2)):S(i,!1,!1,"next")}},a.prev=function(){if(h){var b=L(i,h)-1;if(k[b])i=k[b];else{if(!a.opt.carousel)return;i=k[k.length-1]}"number"==typeof a.opt.animation?(D(j.img,"jslghtbx-animating-prev"),setTimeout(function(){var b=function(){setTimeout(function(){E(j.img,"jslghtbx-animating-next")},a.opt.animation/2)};S(i,!1,b,"prev")},a.opt.animation/2)):S(i,!1,!1,"prev")}},a.close=function(){h=!1,i=!1,j={},k=[],l=!1,D(a.box,"jslghtbx-active"),D(a.wrapper,"jslghtbx-wrapper-active"),D(r,"jslghtbx-active"),D(s,"jslghtbx-active"),a.box.setAttribute("style","padding-top: 0px"),O(),b&&a.box.setAttribute("style","display: none"),a.opt&&F(a.opt.hideOverflow)&&!a.opt.hideOverflow||d.setAttribute("style","overflow: auto"),a.opt.onclose&&a.opt.onclose()}}