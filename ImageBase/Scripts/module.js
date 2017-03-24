angular.module('gallery', ['ngRoute'])

    .config([
        '$locationProvider', '$routeProvider',
        function ($locationProvider, $routeProvider) {
            $routeProvider
                .when('/Angular/gallery', {
                    templateUrl: '/Views/Angular/gallery.html',
                    controller: 'GalleryController'
                })
                .when('/Angular/addImage', {
                    templateUrl: '/Views/Angular/addImage.html',
                    controller: 'AddImageController'
                })
                .otherwise({
                    redirectTo: '/Angular/gallery'
                });

            $locationProvider.html5Mode(true);
        }
    ])

    .controller('GalleryController',
    ['$scope', 'dataCenter',
        function($scope, dataCenter) {
            $scope.albums = [];
            $scope.albumExtensions = [];

            dataCenter.getAlbumNames().then(function(response) {
                $scope.albums = response.data;
                $scope.currentAlbum = $scope.albums[0];

                $scope.changeAlbum();
            });

            $scope.changeAlbum = function () {
                dataCenter.getAlbum($scope.currentAlbum.Id).then(function (response) {
                    $scope.currentAlbum.Images = response.data;

                    $scope.albumExtensions.length = 0;
                    $scope.currentAlbum.Images.forEach(function (image) {
                        if (!$scope.albumExtensions.filter(e => e.name === image.Extension).length > 0) {
                            $scope.albumExtensions.push({ name: image.Extension, state: true });
                        }
                    });
                });
            };

            $scope.extensionChanged = function() {

            };

            $scope.extensionFilter = function (value, index, array) {
                for (var i = 0; i < $scope.albumExtensions.length; i++) {
                    if ($scope.albumExtensions[i].name == value.Extension) {
                        return true;
                    }
                }
                return false;
            };

        }
    ])

    .controller('AddImageController', ['$scope', 'dataCenter', function ($scope, dataCenter) {

        $scope.imageUpload = function (event) {
            var file = event.target.files[0];
            var reader = new FileReader();
            reader.onload = $scope.imageIsLoaded;
            reader.readAsDataURL(file);          
        }

        $scope.imageIsLoaded = function (e) {
            $scope.$apply(function () {
                $scope.imageToAdd = e.target.result;
            });
        }

        $scope.imageAddSubmit = function (e) {
            $.ajax({
                url: "/Image/AddImageAjax",
                type: 'POST',
                data: {
                    fileName: fileInfo.filename,
                    data: fileInfo.data
                },
                success: function (data) {
                    $(submitId).prop('disabled', false);
                    $(previewId).attr("src", "");
                    $(fileId).val("");

                    $(messageClass).hide();
                    $(messageClass).text('Upload completed');
                    $(messageClass).show(500);
                    $(messageClass).hide(2000);
                }
            });

            e.preventDefault();
        };

    }])

    .service('dataCenter', ['$http', function ($http) {
        function getAllImages() {
            var response = $http({
                url: '/Image/GetAllImages'
            });

            return response;
        };

        function getAlbum(selectedAlbumId) {
            var url = '/Image/GetAlbumImages' + '/' + selectedAlbumId;
            var response = $http({
                url: url
            });

            return response;
        };

        function getAlbumNames() {
            var response = $http({
                url: '/Image/getAlbumNames'
            });

            return response;
        };

        function addImage() {

        };

        function removeImage() {

        };

        return {
            getAllImages: getAllImages,
            getAlbum: getAlbum,
            getAlbumNames: getAlbumNames,
            addImage: addImage,
            removeImage: removeImage
        }
    }])

    .directive('myTag', [
        function () {
            return {
                restrict: 'E',
                replace: true,
                templateUrl: '/Views/Angular/myTag.html',
                scope: { user: '=' }
            }
        }
    ])
    ;