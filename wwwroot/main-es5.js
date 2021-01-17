(function () {
  function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

  function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

  function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

  (window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"], {
    /***/
    "+NF9":
    /*!************************************!*\
      !*** ./src/app/_model/activity.ts ***!
      \************************************/

    /*! exports provided: Activity */

    /***/
    function NF9(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "Activity", function () {
        return Activity;
      });

      var Activity = function Activity() {
        _classCallCheck(this, Activity);
      };
      /***/

    },

    /***/
    "/YOv":
    /*!**************************************************!*\
      !*** ./src/app/_services/affirmation.service.ts ***!
      \**************************************************/

    /*! exports provided: AffirmationService */

    /***/
    function YOv(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "AffirmationService", function () {
        return AffirmationService;
      });
      /* harmony import */


      var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! @angular/common/http */
      "tk/3");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var _environments_environment__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! ../../environments/environment */
      "AytR");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var __metadata = undefined && undefined.__metadata || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
      };

      var AffirmationService = /*#__PURE__*/function () {
        function AffirmationService(http) {
          _classCallCheck(this, AffirmationService);

          this.http = http;
          this.baseUrl = _environments_environment__WEBPACK_IMPORTED_MODULE_2__["environment"].apiUrl;
        }

        _createClass(AffirmationService, [{
          key: "getAffirmation",
          value: function getAffirmation(id) {
            return this.http.get(this.baseUrl + 'affirmation/getaffirmation/' + id.toString());
          }
        }, {
          key: "getAffirmationsForUser",
          value: function getAffirmationsForUser(userId) {
            return this.http.get(this.baseUrl + 'affirmation/getaffirmations/' + userId.toString());
          }
        }, {
          key: "createAffirmation",
          value: function createAffirmation(affirmation) {
            var retval = this.http.post(this.baseUrl + 'affirmation/createaffirmation/', affirmation).subscribe(function (result) {
              console.log(result);

              (function (error) {
                console.log(error);
              });
            });
            console.log(retval);
          }
        }, {
          key: "removeAffirmation",
          value: function removeAffirmation(id) {
            return this.http["delete"](this.baseUrl + 'affirmation/removeaffirmation/' + id.toString()).subscribe(function (result) {
              console.log(result);

              (function (error) {
                console.log(error);
              });
            });
          }
        }]);

        return AffirmationService;
      }();

      AffirmationService.ctorParameters = function () {
        return [{
          type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]
        }];
      };

      AffirmationService = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
        providedIn: 'root'
      }), __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])], AffirmationService);
      /***/
    },

    /***/
    0:
    /*!***************************!*\
      !*** multi ./src/main.ts ***!
      \***************************/

    /*! no static exports found */

    /***/
    function _(module, exports, __webpack_require__) {
      module.exports = __webpack_require__(
      /*! E:\VSProjects\MindYourMoodWeb\clientapp\src\main.ts */
      "zUnb");
      /***/
    },

    /***/
    "1M8Y":
    /*!***********************************************************************************************************!*\
      !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/components/activitytime/activitytime.component.html ***!
      \***********************************************************************************************************/

    /*! exports provided: default */

    /***/
    function M8Y(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "<p (click)=\"createActivityTime(1);\">Create Activity Time</p>\n<p (click)=\"getActivityTime(2);\">Get Activity Time (2)</p>\n<p (click)=\"getActivityTimesForActivity(1);\">Get Activity Times for User (4)</p>\n<p (click)=\"removeActivityTime(2);\">Remove Activity Time</p>\n";
      /***/
    },

    /***/
    "2kCK":
    /*!******************************************************************!*\
      !*** ./src/app/components/affirmation/affirmation.component.css ***!
      \******************************************************************/

    /*! exports provided: default */

    /***/
    function kCK(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhZmZpcm1hdGlvbi5jb21wb25lbnQuY3NzIn0= */";
      /***/
    },

    /***/
    "4udQ":
    /*!***************************************************!*\
      !*** ./src/app/_services/activitytime.service.ts ***!
      \***************************************************/

    /*! exports provided: ActivitytimeService */

    /***/
    function udQ(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "ActivitytimeService", function () {
        return ActivitytimeService;
      });
      /* harmony import */


      var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! @angular/common/http */
      "tk/3");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var _environments_environment__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! ../../environments/environment */
      "AytR");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var __metadata = undefined && undefined.__metadata || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
      };

      var ActivitytimeService = /*#__PURE__*/function () {
        function ActivitytimeService(http) {
          _classCallCheck(this, ActivitytimeService);

          this.http = http;
          this.baseUrl = _environments_environment__WEBPACK_IMPORTED_MODULE_2__["environment"].apiUrl;
        }

        _createClass(ActivitytimeService, [{
          key: "getActivityTime",
          value: function getActivityTime(id) {
            return this.http.get(this.baseUrl + 'activitytime/getactivitytime/' + id.toString());
          }
        }, {
          key: "getActivityTimesForActivity",
          value: function getActivityTimesForActivity(activityId) {
            return this.http.get(this.baseUrl + 'activitytime/getactivitytimes/' + activityId.toString());
          }
        }, {
          key: "createActivityTime",
          value: function createActivityTime(activityId, activitytime) {
            var retval = this.http.post(this.baseUrl + 'activitytime/createactivitytime/' + activityId.toString(), activitytime).subscribe(function (result) {
              console.log(result);

              (function (error) {
                console.log(error);
              });
            });
            console.log(retval);
          }
        }, {
          key: "removeActivityTime",
          value: function removeActivityTime(id) {
            return this.http["delete"](this.baseUrl + 'activitytime/removeactivitytime/' + id.toString()).subscribe(function (result) {
              console.log(result);

              (function (error) {
                console.log(error);
              });
            });
          }
        }]);

        return ActivitytimeService;
      }();

      ActivitytimeService.ctorParameters = function () {
        return [{
          type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]
        }];
      };

      ActivitytimeService = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
        providedIn: 'root'
      }), __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])], ActivitytimeService);
      /***/
    },

    /***/
    "5ZPe":
    /*!**********************************************!*\
      !*** ./src/app/_services/account.service.ts ***!
      \**********************************************/

    /*! exports provided: AccountService */

    /***/
    function ZPe(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "AccountService", function () {
        return AccountService;
      });
      /* harmony import */


      var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! @angular/common/http */
      "tk/3");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! rxjs */
      "qCKp");
      /* harmony import */


      var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
      /*! ../../environments/environment */
      "AytR");
      /* harmony import */


      var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
      /*! rxjs/operators */
      "kU1M");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var __metadata = undefined && undefined.__metadata || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
      };

      var AccountService = /*#__PURE__*/function () {
        function AccountService(http) {
          _classCallCheck(this, AccountService);

          this.http = http;
          this.baseUrl = _environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].apiUrl;
          this.currentUserSource = new rxjs__WEBPACK_IMPORTED_MODULE_2__["ReplaySubject"](1);
          this.currentUser$ = this.currentUserSource.asObservable();
        }

        _createClass(AccountService, [{
          key: "login",
          value: function login(model) {
            var _this = this;

            return this.http.post(this.baseUrl + 'account/login', model).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(function (response) {
              var user = response;

              if (user) {
                _this.setCurrentUser(user);
              }

              return user;
            }));
          }
        }, {
          key: "setCurrentUser",
          value: function setCurrentUser(user) {
            user.roles = [];
            var roles = this.getDecodedToken(user.token).role;
            Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
            localStorage.setItem('user', JSON.stringify(user));
            this.currentUserSource.next(user);
          }
        }, {
          key: "logout",
          value: function logout() {
            localStorage.removeItem('user');
            this.currentUserSource.next(null);
          }
        }, {
          key: "getDecodedToken",
          value: function getDecodedToken(token) {
            return JSON.parse(atob(token.split('.')[1]));
          }
        }]);

        return AccountService;
      }();

      AccountService.ctorParameters = function () {
        return [{
          type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]
        }];
      };

      AccountService = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
        providedIn: 'root'
      }), __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])], AccountService);
      /***/
    },

    /***/
    "9vUh":
    /*!****************************************!*\
      !*** ./src/app/home/home.component.ts ***!
      \****************************************/

    /*! exports provided: HomeComponent */

    /***/
    function vUh(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "HomeComponent", function () {
        return HomeComponent;
      });
      /* harmony import */


      var _raw_loader_home_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! raw-loader!./home.component.html */
      "Gd4t");
      /* harmony import */


      var _home_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! ./home.component.css */
      "RV7M");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var __metadata = undefined && undefined.__metadata || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
      };

      var HomeComponent = /*#__PURE__*/function () {
        function HomeComponent() {
          _classCallCheck(this, HomeComponent);
        }

        _createClass(HomeComponent, [{
          key: "ngOnInit",
          value: function ngOnInit() {}
        }]);

        return HomeComponent;
      }();

      HomeComponent.ctorParameters = function () {
        return [];
      };

      HomeComponent = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
        selector: 'app-home',
        template: _raw_loader_home_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
        styles: [_home_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
      }), __metadata("design:paramtypes", [])], HomeComponent);
      /***/
    },

    /***/
    "AytR":
    /*!*****************************************!*\
      !*** ./src/environments/environment.ts ***!
      \*****************************************/

    /*! exports provided: environment */

    /***/
    function AytR(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "environment", function () {
        return environment;
      }); // This file can be replaced during build by using the `fileReplacements` array.
      // `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
      // The list of file replacements can be found in `angular.json`.


      var environment = {
        production: false,
        apiUrl: 'https://localhost:5001/'
      };
      /*
       * In development mode, to ignore zone related error stack frames such as
       * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
       * import the following file, but please comment it out in production mode
       * because it will have performance impact when throw error
       */
      // import 'zone.js/dist/zone-error';  // Included with Angular CLI.

      /***/
    },

    /***/
    "CRhw":
    /*!*********************************************************************************************************!*\
      !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/components/affirmation/affirmation.component.html ***!
      \*********************************************************************************************************/

    /*! exports provided: default */

    /***/
    function CRhw(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "<div>\n  <p (click)=\"createAffirmation();\">Create Affirmation</p>\n  <p (click)=\"getAffirmation(2);\">Get Affirmation (2)</p>\n  <p (click)=\"getAffirmationsForUser(4);\">Get Affirmations for User (4)</p>\n  <p (click)=\"removeAffirmation(6);\">Remove Affirmation</p>\n</div>\n";
      /***/
    },

    /***/
    "Gd4t":
    /*!********************************************************************************!*\
      !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/home/home.component.html ***!
      \********************************************************************************/

    /*! exports provided: default */

    /***/
    function Gd4t(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "<p>home works!</p>\n";
      /***/
    },

    /***/
    "H6fx":
    /*!****************************************************!*\
      !*** ./src/app/fetch-data/fetch-data.component.ts ***!
      \****************************************************/

    /*! exports provided: FetchDataComponent */

    /***/
    function H6fx(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "FetchDataComponent", function () {
        return FetchDataComponent;
      });
      /* harmony import */


      var _raw_loader_fetch_data_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! raw-loader!./fetch-data.component.html */
      "WkqT");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! @angular/common/http */
      "tk/3");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var __metadata = undefined && undefined.__metadata || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
      };

      var FetchDataComponent = function FetchDataComponent(http, baseUrl) {
        var _this2 = this;

        _classCallCheck(this, FetchDataComponent);

        http.get(baseUrl + 'weatherforecast').subscribe(function (result) {
          _this2.forecasts = result;
        }, function (error) {
          return console.error(error);
        });
      };

      FetchDataComponent.ctorParameters = function () {
        return [{
          type: _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"]
        }, {
          type: String,
          decorators: [{
            type: _angular_core__WEBPACK_IMPORTED_MODULE_1__["Inject"],
            args: ['BASE_URL']
          }]
        }];
      };

      FetchDataComponent = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-fetch-data',
        template: _raw_loader_fetch_data_component_html__WEBPACK_IMPORTED_MODULE_0__["default"]
      }), __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], String])], FetchDataComponent);
      /***/
    },

    /***/
    "I1Wz":
    /*!***************************************!*\
      !*** ./src/app/_model/affirmation.ts ***!
      \***************************************/

    /*! exports provided: Affirmation */

    /***/
    function I1Wz(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "Affirmation", function () {
        return Affirmation;
      }); //import { User } from "./user";


      var Affirmation = function Affirmation() {
        _classCallCheck(this, Affirmation);
      };
      /***/

    },

    /***/
    "L1Lo":
    /*!***********************************************!*\
      !*** ./src/app/_services/activity.service.ts ***!
      \***********************************************/

    /*! exports provided: ActivityService */

    /***/
    function L1Lo(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "ActivityService", function () {
        return ActivityService;
      });
      /* harmony import */


      var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! @angular/common/http */
      "tk/3");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var _environments_environment__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! ../../environments/environment */
      "AytR");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var __metadata = undefined && undefined.__metadata || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
      };

      var ActivityService = /*#__PURE__*/function () {
        function ActivityService(http) {
          _classCallCheck(this, ActivityService);

          this.http = http;
          this.baseUrl = _environments_environment__WEBPACK_IMPORTED_MODULE_2__["environment"].apiUrl;
        }

        _createClass(ActivityService, [{
          key: "getActivity",
          value: function getActivity(id) {
            return this.http.get(this.baseUrl + 'activities/getactivity/' + id.toString());
          }
        }, {
          key: "getActivitiesForUser",
          value: function getActivitiesForUser(userId) {
            return this.http.get(this.baseUrl + 'activities/getactivities/' + userId.toString());
          }
        }, {
          key: "createActivity",
          value: function createActivity(activity) {
            var retval = this.http.post(this.baseUrl + 'activities/createactivity/', activity).subscribe(function (result) {
              console.log(result);

              (function (error) {
                console.log(error);
              });
            });
            console.log(retval);
          }
        }, {
          key: "removeActivity",
          value: function removeActivity(id) {
            return this.http["delete"](this.baseUrl + 'activities/removeactivity/' + id.toString()).subscribe(function (result) {
              console.log(result);

              (function (error) {
                console.log(error);
              });
            });
          }
        }]);

        return ActivityService;
      }();

      ActivityService.ctorParameters = function () {
        return [{
          type: _angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]
        }];
      };

      ActivityService = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
        providedIn: 'root'
      }), __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])], ActivityService);
      /***/
    },

    /***/
    "QSfx":
    /*!****************************************************************!*\
      !*** ./src/app/components/activities/activities.component.css ***!
      \****************************************************************/

    /*! exports provided: default */

    /***/
    function QSfx(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhY3Rpdml0aWVzLmNvbXBvbmVudC5jc3MifQ== */";
      /***/
    },

    /***/
    "QdYh":
    /*!**********************************************!*\
      !*** ./src/app/counter/counter.component.ts ***!
      \**********************************************/

    /*! exports provided: CounterComponent */

    /***/
    function QdYh(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "CounterComponent", function () {
        return CounterComponent;
      });
      /* harmony import */


      var _raw_loader_counter_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! raw-loader!./counter.component.html */
      "VECJ");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var CounterComponent = /*#__PURE__*/function () {
        function CounterComponent() {
          _classCallCheck(this, CounterComponent);

          this.currentCount = 0;
        }

        _createClass(CounterComponent, [{
          key: "incrementCounter",
          value: function incrementCounter() {
            this.currentCount++;
          }
        }]);

        return CounterComponent;
      }();

      CounterComponent = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-counter-component',
        template: _raw_loader_counter_component_html__WEBPACK_IMPORTED_MODULE_0__["default"]
      })], CounterComponent);
      /***/
    },

    /***/
    "RV7M":
    /*!*****************************************!*\
      !*** ./src/app/home/home.component.css ***!
      \*****************************************/

    /*! exports provided: default */

    /***/
    function RV7M(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJob21lLmNvbXBvbmVudC5jc3MifQ== */";
      /***/
    },

    /***/
    "Sqpg":
    /*!************************************************!*\
      !*** ./src/app/nav-menu/nav-menu.component.ts ***!
      \************************************************/

    /*! exports provided: NavMenuComponent */

    /***/
    function Sqpg(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "NavMenuComponent", function () {
        return NavMenuComponent;
      });
      /* harmony import */


      var _raw_loader_nav_menu_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! raw-loader!./nav-menu.component.html */
      "XXFw");
      /* harmony import */


      var _nav_menu_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! ./nav-menu.component.css */
      "a56m");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var NavMenuComponent = /*#__PURE__*/function () {
        function NavMenuComponent() {
          _classCallCheck(this, NavMenuComponent);

          this.isExpanded = false;
        }

        _createClass(NavMenuComponent, [{
          key: "collapse",
          value: function collapse() {
            this.isExpanded = false;
          }
        }, {
          key: "toggle",
          value: function toggle() {
            this.isExpanded = !this.isExpanded;
          }
        }]);

        return NavMenuComponent;
      }();

      NavMenuComponent = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
        selector: 'app-nav-menu',
        template: _raw_loader_nav_menu_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
        styles: [_nav_menu_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
      })], NavMenuComponent);
      /***/
    },

    /***/
    "Sy1n":
    /*!**********************************!*\
      !*** ./src/app/app.component.ts ***!
      \**********************************/

    /*! exports provided: AppComponent */

    /***/
    function Sy1n(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "AppComponent", function () {
        return AppComponent;
      });
      /* harmony import */


      var _raw_loader_app_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! raw-loader!./app.component.html */
      "VzVu");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var AppComponent = function AppComponent() {
        _classCallCheck(this, AppComponent);

        this.title = 'app';
      };

      AppComponent = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-root',
        template: _raw_loader_app_component_html__WEBPACK_IMPORTED_MODULE_0__["default"]
      })], AppComponent);
      /***/
    },

    /***/
    "TfXp":
    /*!*****************************************************************!*\
      !*** ./src/app/components/affirmation/affirmation.component.ts ***!
      \*****************************************************************/

    /*! exports provided: AffirmationComponent */

    /***/
    function TfXp(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "AffirmationComponent", function () {
        return AffirmationComponent;
      });
      /* harmony import */


      var _raw_loader_affirmation_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! raw-loader!./affirmation.component.html */
      "CRhw");
      /* harmony import */


      var _affirmation_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! ./affirmation.component.css */
      "2kCK");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var _model_affirmation__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
      /*! ../../_model/affirmation */
      "I1Wz");
      /* harmony import */


      var _services_affirmation_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
      /*! ../../_services/affirmation.service */
      "/YOv");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var __metadata = undefined && undefined.__metadata || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
      };

      var AffirmationComponent = /*#__PURE__*/function () {
        function AffirmationComponent(affirmationService) {
          _classCallCheck(this, AffirmationComponent);

          this.affirmationService = affirmationService;
          this.userAffirmations = [];
        }

        _createClass(AffirmationComponent, [{
          key: "getAffirmation",
          value: function getAffirmation(id) {
            var _this3 = this;

            this.affirmationService.getAffirmation(id).subscribe(function (result) {
              _this3.affirmation = result;
            });
          }
        }, {
          key: "getAffirmationsForUser",
          value: function getAffirmationsForUser(userId) {
            var _this4 = this;

            this.affirmationService.getAffirmationsForUser(userId).subscribe(function (result) {
              _this4.userAffirmations = result;
              console.log(result);
            });
          }
        }, {
          key: "createAffirmation",
          value: function createAffirmation() {
            var aff = new _model_affirmation__WEBPACK_IMPORTED_MODULE_3__["Affirmation"]();
            aff.userId = 4;
            aff.affirmationText = 'This is a new Affirmation';
            this.affirmationService.createAffirmation(aff);
          }
        }, {
          key: "removeAffirmation",
          value: function removeAffirmation(id) {
            this.affirmationService.removeAffirmation(id);
          }
        }]);

        return AffirmationComponent;
      }();

      AffirmationComponent.ctorParameters = function () {
        return [{
          type: _services_affirmation_service__WEBPACK_IMPORTED_MODULE_4__["AffirmationService"]
        }];
      };

      AffirmationComponent = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
        selector: 'app-affirmation',
        template: _raw_loader_affirmation_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
        styles: [_affirmation_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
      }), __metadata("design:paramtypes", [_services_affirmation_service__WEBPACK_IMPORTED_MODULE_4__["AffirmationService"]])], AffirmationComponent);
      /***/
    },

    /***/
    "VECJ":
    /*!**************************************************************************************!*\
      !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/counter/counter.component.html ***!
      \**************************************************************************************/

    /*! exports provided: default */

    /***/
    function VECJ(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "<h1>Counter</h1>\r\n\r\n<p>This is a simple example of an Angular component.</p>\r\n\r\n<p aria-live=\"polite\">Current count: <strong>{{ currentCount }}</strong></p>\r\n\r\n<button class=\"btn btn-primary\" (click)=\"incrementCounter()\">Increment</button>\r\n";
      /***/
    },

    /***/
    "VzVu":
    /*!**************************************************************************!*\
      !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html ***!
      \**************************************************************************/

    /*! exports provided: default */

    /***/
    function VzVu(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "<body>\r\n  <app-nav-menu></app-nav-menu>\r\n  <div class=\"container\">\r\n    <router-outlet></router-outlet>\r\n  </div>\r\n</body>\r\n";
      /***/
    },

    /***/
    "WkqT":
    /*!********************************************************************************************!*\
      !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/fetch-data/fetch-data.component.html ***!
      \********************************************************************************************/

    /*! exports provided: default */

    /***/
    function WkqT(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "<h1 id=\"tableLabel\">Weather forecast</h1>\r\n\r\n<p>This component demonstrates fetching data from the server.</p>\r\n\r\n<p *ngIf=\"!forecasts\"><em>Loading...</em></p>\r\n\r\n<table class='table table-striped' aria-labelledby=\"tableLabel\" *ngIf=\"forecasts\">\r\n  <thead>\r\n    <tr>\r\n      <th>Date</th>\r\n      <th>Temp. (C)</th>\r\n      <th>Temp. (F)</th>\r\n      <th>Summary</th>\r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n    <tr *ngFor=\"let forecast of forecasts\">\r\n      <td>{{ forecast.date }}</td>\r\n      <td>{{ forecast.temperatureC }}</td>\r\n      <td>{{ forecast.temperatureF }}</td>\r\n      <td>{{ forecast.summary }}</td>\r\n    </tr>\r\n  </tbody>\r\n</table>\r\n";
      /***/
    },

    /***/
    "XXFw":
    /*!****************************************************************************************!*\
      !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/nav-menu/nav-menu.component.html ***!
      \****************************************************************************************/

    /*! exports provided: default */

    /***/
    function XXFw(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "<header>\r\n  <nav\r\n    class=\"navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3\"\r\n  >\r\n    <div class=\"container\">\r\n      <a class=\"navbar-brand\" [routerLink]=\"['/']\">MindYourMoodWeb</a>\r\n      <button\r\n        class=\"navbar-toggler\"\r\n        type=\"button\"\r\n        data-toggle=\"collapse\"\r\n        data-target=\".navbar-collapse\"\r\n        aria-label=\"Toggle navigation\"\r\n        [attr.aria-expanded]=\"isExpanded\"\r\n        (click)=\"toggle()\"\r\n      >\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n      </button>\r\n      <div\r\n        class=\"navbar-collapse collapse d-sm-inline-flex justify-content-end\"\r\n        [ngClass]=\"{ show: isExpanded }\"\r\n      >\r\n        <ul class=\"navbar-nav flex-grow\">\r\n          <li class=\"nav-item\"\r\n              [routerLinkActive]=\"['link-active']\"\r\n              [routerLinkActiveOptions]=\"{ exact: true }\">\r\n            <a class=\"nav-link text-dark\" [routerLink]=\"['/']\">Home</a>\r\n          </li>\r\n          <li class=\"nav-item\" [routerLinkActive]=\"['link-active']\">\r\n            <a class=\"nav-link text-dark\" [routerLink]=\"['/counter']\">Counter</a>\r\n          </li>\r\n          <li class=\"nav-item\" [routerLinkActive]=\"['link-active']\">\r\n            <a class=\"nav-link text-dark\" [routerLink]=\"['/fetch-data']\">Fetch data</a>\r\n          </li>\r\n          <li class=\"nav-item\" [routerLinkActive]=\"['link-active']\">\r\n            <a class=\"nav-link text-dark\" [routerLink]=\"['/affirmation']\">Affirmations</a>\r\n          </li>\r\n          <li class=\"nav-item\" [routerLinkActive]=\"['link-active']\">\r\n            <a class=\"nav-link text-dark\" [routerLink]=\"['/activities']\">Activities</a>\r\n          </li>\r\n          <li class=\"nav-item\" [routerLinkActive]=\"['link-active']\">\r\n            <a class=\"nav-link text-dark\" [routerLink]=\"['/activitytime']\">Activity Times</a>\r\n          </li>\r\n        </ul>\r\n      </div>\r\n    </div>\r\n  </nav>\r\n</header>\r\n";
      /***/
    },

    /***/
    "ZAI4":
    /*!*******************************!*\
      !*** ./src/app/app.module.ts ***!
      \*******************************/

    /*! exports provided: AppModule */

    /***/
    function ZAI4(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "AppModule", function () {
        return AppModule;
      });
      /* harmony import */


      var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! @angular/platform-browser */
      "jhN1");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! @angular/forms */
      "3Pt+");
      /* harmony import */


      var _angular_common_http__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
      /*! @angular/common/http */
      "tk/3");
      /* harmony import */


      var _angular_router__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
      /*! @angular/router */
      "tyNb");
      /* harmony import */


      var _app_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
      /*! ./app.component */
      "Sy1n");
      /* harmony import */


      var _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(
      /*! ./nav-menu/nav-menu.component */
      "Sqpg");
      /* harmony import */


      var _home_home_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(
      /*! ./home/home.component */
      "9vUh");
      /* harmony import */


      var _counter_counter_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(
      /*! ./counter/counter.component */
      "QdYh");
      /* harmony import */


      var _fetch_data_fetch_data_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(
      /*! ./fetch-data/fetch-data.component */
      "H6fx");
      /* harmony import */


      var _components_affirmation_affirmation_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(
      /*! ./components/affirmation/affirmation.component */
      "TfXp");
      /* harmony import */


      var _components_activities_activities_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(
      /*! ./components/activities/activities.component */
      "yzWw");
      /* harmony import */


      var _components_activitytime_activitytime_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(
      /*! ./components/activitytime/activitytime.component */
      "nGxX");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var AppModule = function AppModule() {
        _classCallCheck(this, AppModule);
      };

      AppModule = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        declarations: [_app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"], _nav_menu_nav_menu_component__WEBPACK_IMPORTED_MODULE_6__["NavMenuComponent"], _home_home_component__WEBPACK_IMPORTED_MODULE_7__["HomeComponent"], _counter_counter_component__WEBPACK_IMPORTED_MODULE_8__["CounterComponent"], _fetch_data_fetch_data_component__WEBPACK_IMPORTED_MODULE_9__["FetchDataComponent"], _components_affirmation_affirmation_component__WEBPACK_IMPORTED_MODULE_10__["AffirmationComponent"], _components_activities_activities_component__WEBPACK_IMPORTED_MODULE_11__["ActivitiesComponent"], _components_activitytime_activitytime_component__WEBPACK_IMPORTED_MODULE_12__["ActivitytimeComponent"]],
        imports: [_angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"], _angular_common_http__WEBPACK_IMPORTED_MODULE_3__["HttpClientModule"], _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"], _angular_router__WEBPACK_IMPORTED_MODULE_4__["RouterModule"].forRoot([{
          path: '',
          component: _home_home_component__WEBPACK_IMPORTED_MODULE_7__["HomeComponent"],
          pathMatch: 'full'
        }, {
          path: 'counter',
          component: _counter_counter_component__WEBPACK_IMPORTED_MODULE_8__["CounterComponent"]
        }, {
          path: 'fetch-data',
          component: _fetch_data_fetch_data_component__WEBPACK_IMPORTED_MODULE_9__["FetchDataComponent"]
        }, {
          path: 'affirmation',
          component: _components_affirmation_affirmation_component__WEBPACK_IMPORTED_MODULE_10__["AffirmationComponent"]
        }, {
          path: 'activities',
          component: _components_activities_activities_component__WEBPACK_IMPORTED_MODULE_11__["ActivitiesComponent"]
        }, {
          path: 'activitytime',
          component: _components_activitytime_activitytime_component__WEBPACK_IMPORTED_MODULE_12__["ActivitytimeComponent"]
        }])],
        providers: [],
        bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_5__["AppComponent"]]
      })], AppModule);
      /***/
    },

    /***/
    "a56m":
    /*!*************************************************!*\
      !*** ./src/app/nav-menu/nav-menu.component.css ***!
      \*************************************************/

    /*! exports provided: default */

    /***/
    function a56m(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "a.navbar-brand {\r\n  white-space: normal;\r\n  text-align: center;\r\n  word-break: break-all;\r\n}\r\n\r\nhtml {\r\n  font-size: 14px;\r\n}\r\n\r\n@media (min-width: 768px) {\r\n  html {\r\n    font-size: 16px;\r\n  }\r\n}\r\n\r\n.box-shadow {\r\n  box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIm5hdi1tZW51LmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDRSxtQkFBbUI7RUFDbkIsa0JBQWtCO0VBQ2xCLHFCQUFxQjtBQUN2Qjs7QUFFQTtFQUNFLGVBQWU7QUFDakI7O0FBQ0E7RUFDRTtJQUNFLGVBQWU7RUFDakI7QUFDRjs7QUFFQTtFQUNFLDhDQUE4QztBQUNoRCIsImZpbGUiOiJuYXYtbWVudS5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiYS5uYXZiYXItYnJhbmQge1xyXG4gIHdoaXRlLXNwYWNlOiBub3JtYWw7XHJcbiAgdGV4dC1hbGlnbjogY2VudGVyO1xyXG4gIHdvcmQtYnJlYWs6IGJyZWFrLWFsbDtcclxufVxyXG5cclxuaHRtbCB7XHJcbiAgZm9udC1zaXplOiAxNHB4O1xyXG59XHJcbkBtZWRpYSAobWluLXdpZHRoOiA3NjhweCkge1xyXG4gIGh0bWwge1xyXG4gICAgZm9udC1zaXplOiAxNnB4O1xyXG4gIH1cclxufVxyXG5cclxuLmJveC1zaGFkb3cge1xyXG4gIGJveC1zaGFkb3c6IDAgLjI1cmVtIC43NXJlbSByZ2JhKDAsIDAsIDAsIC4wNSk7XHJcbn1cclxuIl19 */";
      /***/
    },

    /***/
    "crnd":
    /*!**********************************************************!*\
      !*** ./src/$$_lazy_route_resource lazy namespace object ***!
      \**********************************************************/

    /*! no static exports found */

    /***/
    function crnd(module, exports) {
      function webpackEmptyAsyncContext(req) {
        // Here Promise.resolve().then() is used instead of new Promise() to prevent
        // uncaught exception popping up in devtools
        return Promise.resolve().then(function () {
          var e = new Error("Cannot find module '" + req + "'");
          e.code = 'MODULE_NOT_FOUND';
          throw e;
        });
      }

      webpackEmptyAsyncContext.keys = function () {
        return [];
      };

      webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
      module.exports = webpackEmptyAsyncContext;
      webpackEmptyAsyncContext.id = "crnd";
      /***/
    },

    /***/
    "iWyD":
    /*!********************************************************************!*\
      !*** ./src/app/components/activitytime/activitytime.component.css ***!
      \********************************************************************/

    /*! exports provided: default */

    /***/
    function iWyD(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJhY3Rpdml0eXRpbWUuY29tcG9uZW50LmNzcyJ9 */";
      /***/
    },

    /***/
    "jnl1":
    /*!****************************************!*\
      !*** ./src/app/_model/activityTime.ts ***!
      \****************************************/

    /*! exports provided: ActivityTime */

    /***/
    function jnl1(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "ActivityTime", function () {
        return ActivityTime;
      });

      var ActivityTime = function ActivityTime() {
        _classCallCheck(this, ActivityTime);
      };
      /***/

    },

    /***/
    "nGxX":
    /*!*******************************************************************!*\
      !*** ./src/app/components/activitytime/activitytime.component.ts ***!
      \*******************************************************************/

    /*! exports provided: ActivitytimeComponent */

    /***/
    function nGxX(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "ActivitytimeComponent", function () {
        return ActivitytimeComponent;
      });
      /* harmony import */


      var _raw_loader_activitytime_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! raw-loader!./activitytime.component.html */
      "1M8Y");
      /* harmony import */


      var _activitytime_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! ./activitytime.component.css */
      "iWyD");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var _model_activityTime__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
      /*! ../../_model/activityTime */
      "jnl1");
      /* harmony import */


      var _services_activitytime_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
      /*! ../../_services/activitytime.service */
      "4udQ");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var __metadata = undefined && undefined.__metadata || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
      };

      var ActivitytimeComponent = /*#__PURE__*/function () {
        function ActivitytimeComponent(activityTimeService) {
          _classCallCheck(this, ActivitytimeComponent);

          this.activityTimeService = activityTimeService;
          this.userActivityTimes = [];
        }

        _createClass(ActivitytimeComponent, [{
          key: "getActivityTime",
          value: function getActivityTime(id) {
            var _this5 = this;

            this.activityTimeService.getActivityTime(id).subscribe(function (result) {
              _this5.activityTime = result;
            });
          }
        }, {
          key: "getActivityTimesForActivity",
          value: function getActivityTimesForActivity(activityId) {
            var _this6 = this;

            this.activityTimeService.getActivityTimesForActivity(activityId).subscribe(function (result) {
              _this6.userActivityTimes = result;
            });
          }
        }, {
          key: "createActivityTime",
          value: function createActivityTime(activityId) {
            var activityTime = new _model_activityTime__WEBPACK_IMPORTED_MODULE_3__["ActivityTime"]();
            activityTime.activityId = activityId;
            activityTime.achievement = 1;
            activityTime.activityName = "Doing some steps exercise";
            activityTime.achievement = 8;
            activityTime.intimacy = 1;
            activityTime.pleasure = 4;
            activityTime.time = new Date(2021, 1, 16, 14, 30, 0, 0);
            this.activityTimeService.createActivityTime(activityId, activityTime);
          }
        }, {
          key: "removeActivityTime",
          value: function removeActivityTime(id) {
            this.activityTimeService.removeActivityTime(id);
          }
        }]);

        return ActivitytimeComponent;
      }();

      ActivitytimeComponent.ctorParameters = function () {
        return [{
          type: _services_activitytime_service__WEBPACK_IMPORTED_MODULE_4__["ActivitytimeService"]
        }];
      };

      ActivitytimeComponent = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
        selector: 'app-activitytime',
        template: _raw_loader_activitytime_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
        styles: [_activitytime_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
      }), __metadata("design:paramtypes", [_services_activitytime_service__WEBPACK_IMPORTED_MODULE_4__["ActivitytimeService"]])], ActivitytimeComponent);
      /***/
    },

    /***/
    "sHxj":
    /*!*******************************************************************************************************!*\
      !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/components/activities/activities.component.html ***!
      \*******************************************************************************************************/

    /*! exports provided: default */

    /***/
    function sHxj(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony default export */


      __webpack_exports__["default"] = "<p (click)=\"createActivity(4);\">Create Activity</p>\n<p (click)=\"getActivity(1);\">Get Activity (1)</p>\n<p (click)=\"getActivitiesForUser(4);\">Get Activity for User (4)</p>\n<p (click)=\"removeActivity(4);\">Remove Activity</p>\n";
      /***/
    },

    /***/
    "yzWw":
    /*!***************************************************************!*\
      !*** ./src/app/components/activities/activities.component.ts ***!
      \***************************************************************/

    /*! exports provided: ActivitiesComponent */

    /***/
    function yzWw(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony export (binding) */


      __webpack_require__.d(__webpack_exports__, "ActivitiesComponent", function () {
        return ActivitiesComponent;
      });
      /* harmony import */


      var _raw_loader_activities_component_html__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! raw-loader!./activities.component.html */
      "sHxj");
      /* harmony import */


      var _activities_component_css__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! ./activities.component.css */
      "QSfx");
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var _model_activity__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
      /*! ../../_model/activity */
      "+NF9");
      /* harmony import */


      var _services_account_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(
      /*! ../../_services/account.service */
      "5ZPe");
      /* harmony import */


      var _services_activity_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(
      /*! ../../_services/activity.service */
      "L1Lo");

      var __decorate = undefined && undefined.__decorate || function (decorators, target, key, desc) {
        var c = arguments.length,
            r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc,
            d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);else for (var i = decorators.length - 1; i >= 0; i--) {
          if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        }
        return c > 3 && r && Object.defineProperty(target, key, r), r;
      };

      var __metadata = undefined && undefined.__metadata || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
      };

      var ActivitiesComponent = /*#__PURE__*/function () {
        function ActivitiesComponent(activityService, accountService) {
          _classCallCheck(this, ActivitiesComponent);

          this.activityService = activityService;
          this.accountService = accountService;
          this.userActivities = [];
        }

        _createClass(ActivitiesComponent, [{
          key: "getActivity",
          value: function getActivity(id) {
            var _this7 = this;

            this.activityService.getActivity(id).subscribe(function (result) {
              _this7.activity = result;
              console.log(result);
            });
          }
        }, {
          key: "getActivitiesForUser",
          value: function getActivitiesForUser(userId) {
            var _this8 = this;

            this.activityService.getActivitiesForUser(userId).subscribe(function (result) {
              _this8.userActivities = result;
            });
          }
        }, {
          key: "createActivity",
          value: function createActivity(userId) {
            var activity = new _model_activity__WEBPACK_IMPORTED_MODULE_3__["Activity"]();
            activity.userID = userId;
            activity.activityTimes = [];
            activity.activityDate = new Date(2021, 1, 16, 15, 30, 0, 0);
            this.activityService.createActivity(activity);
          }
        }, {
          key: "removeActivity",
          value: function removeActivity(id) {
            this.activityService.removeActivity(id);
          }
        }]);

        return ActivitiesComponent;
      }();

      ActivitiesComponent.ctorParameters = function () {
        return [{
          type: _services_activity_service__WEBPACK_IMPORTED_MODULE_5__["ActivityService"]
        }, {
          type: _services_account_service__WEBPACK_IMPORTED_MODULE_4__["AccountService"]
        }];
      };

      ActivitiesComponent = __decorate([Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["Component"])({
        selector: 'app-activities',
        template: _raw_loader_activities_component_html__WEBPACK_IMPORTED_MODULE_0__["default"],
        styles: [_activities_component_css__WEBPACK_IMPORTED_MODULE_1__["default"]]
      }), __metadata("design:paramtypes", [_services_activity_service__WEBPACK_IMPORTED_MODULE_5__["ActivityService"], _services_account_service__WEBPACK_IMPORTED_MODULE_4__["AccountService"]])], ActivitiesComponent);
      /***/
    },

    /***/
    "zUnb":
    /*!*********************!*\
      !*** ./src/main.ts ***!
      \*********************/

    /*! no exports provided */

    /***/
    function zUnb(module, __webpack_exports__, __webpack_require__) {
      "use strict";

      __webpack_require__.r(__webpack_exports__);
      /* harmony import */


      var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(
      /*! @angular/core */
      "fXoL");
      /* harmony import */


      var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(
      /*! @angular/platform-browser-dynamic */
      "a3Wg");
      /* harmony import */


      var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(
      /*! ./app/app.module */
      "ZAI4");
      /* harmony import */


      var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(
      /*! ./environments/environment */
      "AytR");

      if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
      }

      Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])["catch"](function (err) {
        return console.log(err);
      });
      /***/
    }
  }, [[0, "runtime", "vendor"]]]);
})();
//# sourceMappingURL=main-es5.js.map