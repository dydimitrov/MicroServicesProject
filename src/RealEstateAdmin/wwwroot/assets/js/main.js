/*
Theme Name: iProperty
Theme URI: http://immersivesoul.com/iproperty/
Description: iProperty Responsive HTML5 Bootstrap Template
Author: Immersive Soul
Author URI: http://immersivesoul.com
Version: 1.0
*/

// Theme
window.theme = {};

// Theme Common Functions
window.theme.fn = {

    getOptions: function(opts) {

        if (typeof(opts) == 'object') {

            return opts;

        } else if (typeof(opts) == 'string') {

            try {
                return JSON.parse(opts.replace(/'/g,'"').replace(';',''));
            } catch(e) {
                return {};
            }

        } else {

            return {};

        }

    }

};

// Animate
(function(theme, $) {

    theme = theme || {};

    var instanceName = '__animate';

    var PluginAnimate = function($el, opts) {
        return this.initialize($el, opts);
    };

    PluginAnimate.defaults = {
        accX: 0,
        accY: -150,
        delay: 1,
        duration: '1s'
    };

    PluginAnimate.prototype = {
        initialize: function($el, opts) {
            if ($el.data(instanceName)) {
                return this;
            }

            this.$el = $el;

            this
                .setData()
                .setOptions(opts)
                .build();

            return this;
        },

        setData: function() {
            this.$el.data(instanceName, this);

            return this;
        },

        setOptions: function(opts) {
            this.options = $.extend(true, {}, PluginAnimate.defaults, opts, {
                wrapper: this.$el
            });

            return this;
        },

        build: function() {
            var self = this,
                $el = this.options.wrapper,
                delay = 0,
                duration = '1s';

            $el.addClass('appear-animation animated');

            if (!$('html').hasClass('no-csstransitions') && $(window).width() > 767) {

                $el.appear(function() {

                    $el.one('animation:show', function(ev) {
                        delay = ($el.attr('data-appear-animation-delay') ? $el.attr('data-appear-animation-delay') : self.options.delay);
                        duration = ($el.attr('data-appear-animation-duration') ? $el.attr('data-appear-animation-duration') : self.options.duration);

                        if (duration != '1s') {
                            $el.css('animation-duration', duration);
                        }

                        setTimeout(function() {
                            $el.addClass($el.attr('data-appear-animation') + ' appear-animation-visible');
                        }, delay);
                    });

                    $el.trigger('animation:show');

                }, {
                    accX: self.options.accX,
                    accY: self.options.accY
                });

            } else {

                $el.addClass('appear-animation-visible');

            }

            return this;
        }
    };

    // expose to scope
    $.extend(theme, {
        PluginAnimate: PluginAnimate
    });

    // jquery plugin
    $.fn.themePluginAnimate = function(opts) {
        return this.map(function() {
            var $this = $(this);

            if ($this.data(instanceName)) {
                return $this.data(instanceName);
            } else {
                return new PluginAnimate($this, opts);
            }

        });
    };

}).apply(this, [window.theme, jQuery]);

jQuery(document).ready(function($) {

"use strict";

    /*============================================================*/
    /* 01  SLICK SLIDER */
    /*============================================================*/
    $('.slick-carousel').slick({
        dots: true,
        infinite: true,
        autoplay: true,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        responsive: [{
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });

    /*============================================================*/
    /* 01  SLICK THUMBNAIL SLIDER */
    /*============================================================*/
    $('.slick-thumbnail').slick({
        autoplay: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
        fade: false,
        asNavFor: '.slick-thumbnail-nav',
        dots: false,
        infinite: true
    });
    $('.slick-thumbnail-nav').slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        asNavFor: '.slick-thumbnail',
        arrows: false,
        dots: false,
        centerMode: true,
        arrows: true,
        focusOnSelect: true
    });

    /*============================================================*/
    /* 01  SLICK THUMBNAIL SLIDER */
    /*============================================================*/
    $('.multiple-items').slick({
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 3
    });

    /*============================================================*/
    /* 01  SLICK SINGLE IMAGE SLIDER */
    /*============================================================*/
    $('.slick-single').slick({
        autoplay: true,
        dots: true,
        arrows: false,
        infinite: true,
        speed: 500,
        fade: false,
        cssEase: 'linear'
    });

});

// Match Height
(function(theme, $) {

    theme = theme || {};

    var instanceName = '__matchHeight';

    var PluginMatchHeight = function($el, opts) {
        return this.initialize($el, opts);
    };

    PluginMatchHeight.defaults = {
        byRow: true,
        property: 'height',
        target: null,
        remove: false
    };

    PluginMatchHeight.prototype = {
        initialize: function($el, opts) {
            if ($el.data(instanceName)) {
                return this;
            }

            this.$el = $el;

            this
                .setData()
                .setOptions(opts)
                .build();

            return this;
        },

        setData: function() {
            this.$el.data(instanceName, this);

            return this;
        },

        setOptions: function(opts) {
            this.options = $.extend(true, {}, PluginMatchHeight.defaults, opts, {
                wrapper: this.$el
            });

            return this;
        },

        build: function() {
            if (!($.isFunction($.fn.matchHeight))) {
                return this;
            }

            var self = this;

            self.options.wrapper.matchHeight(self.options);

            return this;
        }

    };

    // expose to scope
    $.extend(theme, {
        PluginMatchHeight: PluginMatchHeight
    });

    // jquery plugin
    $.fn.themePluginMatchHeight = function(opts) {
        return this.map(function() {
            var $this = $(this);

            if ($this.data(instanceName)) {
                return $this.data(instanceName);
            } else {
                return new PluginMatchHeight($this, opts);
            }

        });
    }

}).apply(this, [window.theme, jQuery]);

// Parallax
(function(theme, $) {

    theme = theme || {};

    var instanceName = '__parallax';

    var PluginParallax = function($el, opts) {
        return this.initialize($el, opts);
    };

    PluginParallax.defaults = {
        speed: 1.5,
        horizontalPosition: '50%',
        offset: 0
    };

    PluginParallax.prototype = {
        initialize: function($el, opts) {
            if ($el.data(instanceName)) {
                return this;
            }

            this.$el = $el;

            this
                .setData()
                .setOptions(opts)
                .build();

            return this;
        },

        setData: function() {
            this.$el.data(instanceName, this);

            return this;
        },

        setOptions: function(opts) {
            this.options = $.extend(true, {}, PluginParallax.defaults, opts, {
                wrapper: this.$el
            });

            return this;
        },

        build: function() {
            var self = this,
                $window = $(window),
                offset,
                yPos,
                bgpos,
                background;

            // Create Parallax Element
            background = $('<div class="parallax-background"></div>');

            // Set Style for Parallax Element
            background.css({
                'background-image' : 'url(' + self.options.wrapper.data('image-src') + ')',
                'background-size' : 'cover',
                'position' : 'absolute',
                'top' : 0,
                'left' : 0,
                'width' : '100%',
                'height' : '180%'
            });

            // Add Parallax Element on DOM
            self.options.wrapper.prepend(background);

            // Set Overlfow Hidden and Position Relative to Parallax Wrapper
            self.options.wrapper.css({
                'position' : 'relative',
                'overflow' : 'hidden'
            });

            // Parallax Effect on Scroll & Resize
            var parallaxEffectOnScrolResize = function() {
                $window.on('scroll resize', function() {
                    offset  = self.options.wrapper.offset();
                    yPos    = -($window.scrollTop() - (offset.top - 100)) / ((self.options.speed + 2 ) + (self.options.offset));
                    plxPos  = (yPos < 0) ? Math.abs(yPos) : -Math.abs(yPos);
                    background.css({
                        'transform' : 'translate3d(0, '+ plxPos +'px, 0)',
                        'background-position-x' : self.options.horizontalPosition
                    });
                });

                $window.trigger('scroll');
            }

            if (!$.browser.mobile) {
                parallaxEffectOnScrolResize();
            } else {
                if( self.options.enableOnMobile == true ) {
                    parallaxEffectOnScrolResize();
                } else {
                    self.options.wrapper.addClass('parallax-disabled');
                }
            }

            return this;
        }
    };

    // expose to scope
    $.extend(theme, {
        PluginParallax: PluginParallax
    });

    // jquery plugin
    $.fn.themePluginParallax = function(opts) {
        return this.map(function() {
            var $this = $(this);

            if ($this.data(instanceName)) {
                return $this.data(instanceName);
            } else {
                return new PluginParallax($this, opts);
            }

        });
    }

}).apply(this, [window.theme, jQuery]);

// Scroll to Top
(function(theme, $) {

    theme = theme || {};

    $.extend(theme, {

        PluginScrollToTop: {

            defaults: {
                wrapper: $('body'),
                offset: 150,
                buttonClass: 'scroll-to-top',
                iconClass: 'fa fa-arrow-up',
                delay: 1000,
                visibleMobile: false,
                label: false,
                easing: 'easeOutQuint'
            },

            initialize: function(opts) {
                initialized = true;

                this
                    .setOptions(opts)
                    .build()
                    .events();

                return this;
            },

            setOptions: function(opts) {
                this.options = $.extend(true, {}, this.defaults, opts);

                return this;
            },

            build: function() {
                var self = this,
                    $el;

                // Base HTML Markup
                $el = $('<a />')
                    .addClass(self.options.buttonClass)
                    .attr({
                        'href': '#',
                    })
                    .append(
                        $('<i />')
                        .addClass(self.options.iconClass)
                );

                // Visible Mobile
                if (!self.options.visibleMobile) {
                    $el.addClass('hidden-mobile');
                }

                // Label
                if (self.options.label) {
                    $el.append(
                        $('<span />').html(self.options.label)
                    );
                }

                this.options.wrapper.append($el);

                this.$el = $el;

                return this;
            },

            events: function() {
                var self = this,
                    _isScrolling = false;

                // Click Element Action
                self.$el.on('click', function(e) {
                    e.preventDefault();
                    $('body, html').animate({
                        scrollTop: 0
                    }, self.options.delay, self.options.easing);
                    return false;
                });

                // Show/Hide Button on Window Scroll event.
                $(window).scroll(function() {

                    if (!_isScrolling) {

                        _isScrolling = true;

                        if ($(window).scrollTop() > self.options.offset) {

                            self.$el.stop(true, true).addClass('visible');
                            _isScrolling = false;

                        } else {

                            self.$el.stop(true, true).removeClass('visible');
                            _isScrolling = false;

                        }

                    }

                });

                return this;
            }

        }

    });

}).apply(this, [window.theme, jQuery]);

// Progress Bar
(function(theme, $) {

    theme = theme || {};

    var instanceName = '__progressBar';

    var PluginProgressBar = function($el, opts) {
        return this.initialize($el, opts);
    };

    PluginProgressBar.defaults = {
        accX: 0,
        accY: -50,
        delay: 1
    };

    PluginProgressBar.prototype = {
        initialize: function($el, opts) {
            if ($el.data(instanceName)) {
                return this;
            }

            this.$el = $el;

            this
                .setData()
                .setOptions(opts)
                .build();

            return this;
        },

        setData: function() {
            this.$el.data(instanceName, this);

            return this;
        },

        setOptions: function(opts) {
            this.options = $.extend(true, {}, PluginProgressBar.defaults, opts, {
                wrapper: this.$el
            });

            return this;
        },

        build: function() {
            if (!($.isFunction($.fn.appear))) {
                return this;
            }

            var self = this,
                $el = this.options.wrapper,
                delay = 1;

            $el.appear(function() {

                delay = ($el.attr('data-appear-animation-delay') ? $el.attr('data-appear-animation-delay') : self.options.delay);

                $el.addClass($el.attr('data-appear-animation'));

                setTimeout(function() {

                    $el.animate({
                        width: $el.attr('data-appear-progress-animation')
                    }, 1500, 'easeOutQuad', function() {
                        $el.find('.progress-bar-tooltip').animate({
                            opacity: 1
                        }, 500, 'easeOutQuad');
                    });

                }, delay);

            }, {
                accX: self.options.accX,
                accY: self.options.accY
            });

            return this;
        }
    };

    // expose to scope
    $.extend(theme, {
        PluginProgressBar: PluginProgressBar
    });

    // jquery plugin
    $.fn.themePluginProgressBar = function(opts) {
        return this.map(function() {
            var $this = $(this);

            if ($this.data(instanceName)) {
                return $this.data(instanceName);
            } else {
                return new PluginProgressBar($this, opts);
            }

        });
    }

}).apply(this, [window.theme, jQuery]);

// Masonry
(function(theme, $) {

    theme = theme || {};

    var instanceName = '__masonry';

    var PluginMasonry = function($el, opts) {
        return this.initialize($el, opts);
    };

    PluginMasonry.defaults = {
        itemSelector: 'li'
    };

    PluginMasonry.prototype = {
        initialize: function($el, opts) {
            if ($el.data(instanceName)) {
                return this;
            }

            this.$el = $el;

            this
                .setData()
                .setOptions(opts)
                .build();

            return this;
        },

        setData: function() {
            this.$el.data(instanceName, this);

            return this;
        },

        setOptions: function(opts) {
            this.options = $.extend(true, {}, PluginMasonry.defaults, opts, {
                wrapper: this.$el
            });

            return this;
        },

        build: function() {
            if (!($.isFunction($.fn.isotope))) {
                return this;
            }

            var self = this,
                $window = $(window);

            self.$loader = false;

            if (self.options.wrapper.parents('.masonry-loader').get(0)) {
                self.$loader = self.options.wrapper.parents('.masonry-loader');
                self.createLoader();
            }

            self.options.wrapper.one('layoutComplete', function(event, laidOutItems) {
                self.removeLoader();
            });

            self.options.wrapper.waitForImages(function() {
                self.options.wrapper.isotope(this.options);
            });

            setTimeout(function() {
                self.removeLoader();
            }, 3000);

            return this;
        },

        createLoader: function() {
            var self = this;

            var loaderTemplate = [
                '<div class="bounce-loader">',
                    '<div class="bounce1"></div>',
                    '<div class="bounce2"></div>',
                    '<div class="bounce3"></div>',
                '</div>'
            ].join('');

            self.$loader.append(loaderTemplate);

            return this;
        },

        removeLoader: function() {

            var self = this;

            if (self.$loader) {

                self.$loader.removeClass('masonry-loader-showing');

                setTimeout(function() {
                    self.$loader.addClass('masonry-loader-loaded');
                }, 300);

            }

        }
    };

    // expose to scope
    $.extend(theme, {
        PluginMasonry: PluginMasonry
    });

    // jquery plugin
    $.fn.themePluginMasonry = function(opts) {
        return this.map(function() {
            var $this = $(this);

            if ($this.data(instanceName)) {
                return $this.data(instanceName);
            } else {
                return new PluginMasonry($this, opts);
            }

        });
    }

}).apply(this, [window.theme, jQuery]);

// Sort
(function(theme, $) {

    theme = theme || {};

    var instanceName = '__sort';

    var PluginSort = function($el, opts) {
        return this.initialize($el, opts);
    };

    PluginSort.defaults = {
        useHash: true,
        itemSelector: '.isotope-item',
        layoutMode: 'masonry',
        filter: '*',
        hiddenStyle: {
            opacity: 0
        },
        visibleStyle: {
            opacity: 1
        },
        stagger: 30,
        isOriginLeft: ($('html').attr('dir') == 'rtl' ? false : true)
    };

    PluginSort.prototype = {
        initialize: function($el, opts) {
            if ($el.data(instanceName)) {
                return this;
            }

            this.$el = $el;

            this
                .setData()
                .setOptions(opts)
                .build();

            return this;
        },

        setData: function() {
            this.$el.data(instanceName, this);

            return this;
        },

        setOptions: function(opts) {
            this.options = $.extend(true, {}, PluginSort.defaults, opts, {
                wrapper: this.$el
            });

            return this;
        },

        build: function() {
            if (!($.isFunction($.fn.isotope))) {
                return this;
            }

            var self = this,
                $source = this.options.wrapper,
                $destination = $('.sort-destination[data-sort-id="' + $source.attr('data-sort-id') + '"]'),
                $window = $(window);

            if ($destination.get(0)) {

                self.$source = $source;
                self.$destination = $destination;
                self.$loader = false;

                self.setParagraphHeight($destination);

                if (self.$destination.parents('.sort-destination-loader').get(0)) {
                    self.$loader = self.$destination.parents('.sort-destination-loader');
                    self.createLoader();
                }

                $destination.attr('data-filter', '*');

                $destination.one('layoutComplete', function(event, laidOutItems) {
                    self.removeLoader();
                });

                $destination.waitForImages(function() {
                    $destination.isotope(self.options);
                    self.events();
                });

                setTimeout(function() {
                    self.removeLoader();
                }, 3000);

            }

            return this;
        },

        events: function() {
            var self = this,
                filter = null,
                $window = $(window);

            self.$source.find('a').click(function(e) {
                e.preventDefault();

                filter = $(this).parent().data('option-value');

                self.setFilter(filter);

                if (e.originalEvent) {
                    self.$source.trigger('filtered');
                }

                return this;
            });

            self.$destination.trigger('filtered');
            self.$source.trigger('filtered');

            if (self.options.useHash) {
                self.hashEvents();
            }

            $window.on('resize', function() {
                setTimeout(function() {
                    self.$destination.isotope('layout');
                }, 300);
            });

            setTimeout(function() {
                $window.trigger('resize');
            }, 300);

            return this;
        },

        setFilter: function(filter) {
            var self = this,
                page = false,
                currentFilter = filter;

            self.$source.find('li.active').removeClass('active');
            self.$source.find('li[data-option-value="' + filter + '"]').addClass('active');

            self.options.filter = currentFilter;

            if (self.$destination.attr('data-current-page')) {
                currentFilter = currentFilter + '[data-page-rel=' + self.$destination.attr('data-current-page') + ']';
            }

            self.$destination.attr('data-filter', filter).isotope({
                filter: currentFilter
            }).one('arrangeComplete', function( event, filteredItems ) {
                
                if (self.options.useHash) {
                    if (window.location.hash != '' || self.options.filter.replace('.', '') != '*') {
                        window.location.hash = self.options.filter.replace('.', '');
                    }
                }
                
                $(window).trigger('scroll');

            }).trigger('filtered');

            return this;
        },

        hashEvents: function() {
            var self = this,
                hash = null,
                hashFilter = null,
                initHashFilter = '.' + location.hash.replace('#', '');

            if (initHashFilter != '.' && initHashFilter != '.*') {
                self.setFilter(initHashFilter);
            }

            $(window).on('hashchange', function(e) {

                hashFilter = '.' + location.hash.replace('#', '');
                hash = (hashFilter == '.' || hashFilter == '.*' ? '*' : hashFilter);

                self.setFilter(hash);

            });

            return this;
        },

        setParagraphHeight: function() {
            var self = this,
                minParagraphHeight = 0,
                paragraphs = $('span.thumb-info-caption p', self.$destination);

            paragraphs.each(function() {
                if ($(this).height() > minParagraphHeight) {
                    minParagraphHeight = ($(this).height() + 10);
                }
            });

            paragraphs.height(minParagraphHeight);

            return this;
        },

        createLoader: function() {
            var self = this;

            var loaderTemplate = [
                '<div class="bounce-loader">',
                    '<div class="bounce1"></div>',
                    '<div class="bounce2"></div>',
                    '<div class="bounce3"></div>',
                '</div>'
            ].join('');

            self.$loader.append(loaderTemplate);

            return this;
        },

        removeLoader: function() {

            var self = this;

            if (self.$loader) {

                self.$loader.removeClass('sort-destination-loader-showing');

                setTimeout(function() {
                    self.$loader.addClass('sort-destination-loader-loaded');
                }, 300);

            }

        }

    };

    // expose to scope
    $.extend(theme, {
        PluginSort: PluginSort
    });

    // jquery plugin
    $.fn.themePluginSort = function(opts) {
        return this.map(function() {
            var $this = $(this);

            if ($this.data(instanceName)) {
                return $this.data(instanceName);
            } else {
                return new PluginSort($this, opts);
            }

        });
    }

}).apply(this, [window.theme, jQuery]);

// Carousel
(function(theme, $) {

    theme = theme || {};

    var instanceName = '__carousel';

    var PluginCarousel = function($el, opts) {
        return this.initialize($el, opts);
    };

    PluginCarousel.defaults = {
        loop: true,
        responsive: {
            0: {
                items: 1
            },
            479: {
                items: 1
            },
            768: {
                items: 2
            },
            979: {
                items: 3
            },
            1199: {
                items: 4
            }
        },
        navText: []
    };

    PluginCarousel.prototype = {
        initialize: function($el, opts) {
            if ($el.data(instanceName)) {
                return this;
            }

            this.$el = $el;

            this
                .setData()
                .setOptions(opts)
                .build();

            return this;
        },

        setData: function() {
            this.$el.data(instanceName, this);

            return this;
        },

        setOptions: function(opts) {
            this.options = $.extend(true, {}, PluginCarousel.defaults, opts, {
                wrapper: this.$el
            });

            return this;
        },

        build: function() {
            if (!($.isFunction($.fn.owlCarousel))) {
                return this;
            }

            var self = this,
                $el = this.options.wrapper;

            // Add Theme Class
            $el.addClass('owl-theme');

            // Force RTL according to HTML dir attribute
            if ($('html').attr('dir') == 'rtl') {
                this.options = $.extend(true, {}, this.options, {
                    rtl: true
                });
            }

            if (this.options.items == 1) {
                this.options.responsive = {}
            }

            if (this.options.items > 4) {
                this.options = $.extend(true, {}, this.options, {
                    responsive: {
                        1199: {
                            items: this.options.items
                        }
                    }
                });
            }

            // Auto Height Fixes
            if (this.options.autoHeight) {
                var itemsHeight = [];

                $el.find('.owl-item').each(function(){
                    if( $(this).hasClass('active') ) {
                        itemsHeight.push( $(this).height() );
                    }
                });

                $(window).afterResize(function() {
                    $el.find('.owl-stage-outer').height( Math.max.apply(null, itemsHeight) );
                });

                $(window).on('load', function() {
                    $el.find('.owl-stage-outer').height( Math.max.apply(null, itemsHeight) );
                });
            }

            // Initialize OwlCarousel
            $el.owlCarousel(this.options).addClass('owl-carousel-init');

            return this;
        }
    };

    // expose to scope
    $.extend(theme, {
        PluginCarousel: PluginCarousel
    });

    // jquery plugin
    $.fn.themePluginCarousel = function(opts) {
        return this.map(function() {
            var $this = $(this);

            if ($this.data(instanceName)) {
                return $this.data(instanceName);
            } else {
                return new PluginCarousel($this, opts);
            }

        });
    }

}).apply(this, [window.theme, jQuery]);