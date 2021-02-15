import { TestBed } from '@angular/core/testing';

import { AutokService } from './autok.service';

describe('AutokService', () => {
  let service: AutokService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AutokService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
